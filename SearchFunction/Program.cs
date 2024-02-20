using SearchFunction.Models;

Console.WriteLine("Hello, World!");


List<Relationship> relationship = new List<Relationship>
        {
            new Relationship {Id = 1, Name = "Grand Father" },
            new Relationship {Id = 2,Name = "Son" },
            new Relationship {Id = 3, Name = "Daughter" }
        };
List<Person> families = new List<Person>() {
    new Person  {Id = 1, Name = "Lee", DateOfBirth = new DateTime(1890, 5, 7) },
     new Person {Id = 2, Name = "Robert", DateOfBirth = new DateTime(1920, 7, 10)},
     new Person {Id = 3, Name = "Kris", DateOfBirth = new DateTime(1944, 12, 26)}
};
List<FamilyRelation> familyRelations = new List<FamilyRelation>() { 
    new FamilyRelation { Id = 1 , PersonId = 1 ,  RelatedPersonId =  2 ,RelationshipTypeId = 2},
    new FamilyRelation { Id = 2 , PersonId = 1 ,  RelatedPersonId =  3 ,RelationshipTypeId = 3}
};


string name = Console.ReadLine();
SearchOlderToYounger(name);
SearchYoungerToOlder(name);
void SearchOlderToYounger(string name)
{
    var person = families.FirstOrDefault(p => p.Name == name);
    if (person != null)
    {
        var relatives = familyRelations.Where(fr => fr.PersonId == person.Id)
            .OrderBy(fr => families.First(p => p.Id == fr.RelatedPersonId).DateOfBirth)
            .Select(fr => families.First(p => p.Id == fr.RelatedPersonId).Name)
            .ToList();

        if (relatives.Any())
        {
            Console.WriteLine($"Result: {string.Join(" > ", relatives)}");
        }
        else
        {
            Console.WriteLine("Result: Not Found");
        }
    }
    else
    {
        Console.WriteLine("Result: Not Found");
    }
}
void SearchYoungerToOlder(string name)
{
    var person = families.FirstOrDefault(p => p.Name == name);
    if (person != null)
    {
        var relatives = familyRelations.Where(fr => fr.PersonId == person.Id)
            .OrderByDescending(fr => families.First(fam => fam.Id == fr.RelatedPersonId).DateOfBirth)
            .Select(fr => families.First(fam => fam.Id == fr.RelatedPersonId).Name)
            .ToList();

        if (relatives.Any())
        {
            Console.WriteLine($"Result: {string.Join(" < ", relatives)}");
        }
        else
        {
            Console.WriteLine("Result: Not Found");
        }
    }
    else
    {
        Console.WriteLine("Result: Not Found");
    }
}
