using System.ComponentModel.DataAnnotations;

namespace Family.Models
{
    public class Relation
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
