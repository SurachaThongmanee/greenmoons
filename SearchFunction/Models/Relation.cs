using System.ComponentModel.DataAnnotations;

namespace SearchFunction.Models
{
    public class Relationship : _BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<FamilyRelation> FamilyRelations { get; set; }
    }
}
