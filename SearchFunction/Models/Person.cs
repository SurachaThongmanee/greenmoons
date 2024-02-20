using System.ComponentModel.DataAnnotations;

namespace SearchFunction.Models
{
    public class Person : _BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<FamilyRelation> FamilyRelations { get; set; }
        public virtual ICollection<FamilyRelation> RelatedFamilyRelations { get; set; }
    }
}
