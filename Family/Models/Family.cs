using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Family.Models
{
    public class Family
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ParentId { get; set; }
        public int? RelationId { get; set; }
        public virtual Family Parent { get; set; }
        public DateTime CreatedDatetime { get; set; }   
        public DateTime UpdatedDatetime { get; set; }
        [ForeignKey("RelationId")]
        public virtual Relation Relation { get; set; }
    }
}
