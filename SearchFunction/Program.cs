using Microsoft.EntityFrameworkCore;
using SearchFunction.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
Console.WriteLine("Hello, World!");


List<Relationship> relationships = new List<Relationship>
        {
            new Relationship { Name = "Grand Father" },
            new Relationship {Name = "Son" },
            new Relationship { Name = "Daughter" }
        };
List<Person> families = new List<Person>() {
    new Person  { Name = "Lee", DateOfBirth = new DateTime(1890, 5, 7) },
     new Person { Name = "Robert", DateOfBirth = new DateTime(1920, 7, 10)},
     new Person { Name = "Kris", DateOfBirth = new DateTime(1944, 12, 26)}
};
List<FamilyRelation> familyRelations = new List<FamilyRelation>() {
    new FamilyRelation {  PersonId = 1 ,  RelatedPersonId =  2 ,RelationshipTypeId = 2},
    new FamilyRelation {  PersonId = 1 ,  RelatedPersonId =  3 ,RelationshipTypeId = 3}
};

# region Add Data to DB
//using (var dbContext = new MyDbContext())
//{
//    PopulateDatabase(dbContext);
//}
#endregion

string name = Console.ReadLine();
SearchOlderToYounger(name);
SearchYoungerToOlder(name);
void SearchOlderToYounger(string name)
{
    using (var dbContext = new MyDbContext())
    {
        var relatives = dbContext.FamilyRelations.Where(fr => fr.Person.Name == name)
            .OrderBy(fr => fr.RelatedPerson.DateOfBirth)
            .Select(fr => fr.RelatedPerson.Name)
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
}
void SearchYoungerToOlder(string name)
{
    using (var dbContext = new MyDbContext())
    {
        var relatives = dbContext.FamilyRelations.Where(fr => fr.Person.Name == name)
            .OrderByDescending(fr => fr.RelatedPerson.DateOfBirth)
            .Select(fr => fr.RelatedPerson.Name)
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
}
void PopulateDatabase(MyDbContext dbContext)
{
    try
    {
        dbContext.Relationships.AddRange(relationships);
        dbContext.Person.AddRange(families);
        dbContext.FamilyRelations.AddRange(familyRelations);
        dbContext.SaveChanges();
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine("Error while saving changes to the database:");
        Console.WriteLine(ex.InnerException.Message);
    }
}
public class MyDbContext : DbContext
{
    public DbSet<Person> Person { get; set; }
    public DbSet<Relationship> Relationships { get; set; }
    public DbSet<FamilyRelation> FamilyRelations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        #region Connection String
        optionsBuilder.UseSqlServer("Server=DESKTOP-886VTLI;Database=dev;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;");
        #endregion
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FamilyRelation>()
            .HasOne(fr => fr.Person)
            .WithMany()
            .HasForeignKey(fr => fr.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<FamilyRelation>()
            .HasOne(fr => fr.RelatedPerson)
            .WithMany()
            .HasForeignKey(fr => fr.RelatedPersonId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<FamilyRelation>()
            .HasOne(fr => fr.RelationshipType)
            .WithMany(r => r.FamilyRelations)
            .HasForeignKey(fr => fr.RelationshipTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

