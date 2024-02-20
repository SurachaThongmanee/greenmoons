using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFunction.Models
{
    public class FamilyRelation : _BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public int RelationshipTypeId { get; set; }



        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
        [ForeignKey("RelatedPersonId")]
        public virtual Person RelatedPerson { get; set; }
        [ForeignKey("RelationshipTypeId")]
        public virtual Relationship RelationshipType { get; set; }


    }
}
