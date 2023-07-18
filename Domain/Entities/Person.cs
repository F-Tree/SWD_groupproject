using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {       
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; } // Alive, Deceased, ...
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string? BirthPlace { get; set; }
        public string? RestingPlace { get; set; }
        public Guid? Father { get; set; }
        public Guid? Mother { get; set; }
        public Guid? Spouse { get; set; }
        public Guid? Children { get; set; }
        public Guid? FamilyTreeId { get; set; }
        public FamilyTree FamilyTree { get; set; }
        public ICollection<TreeRelationship> TreeRelationshipOne { get; set; }
        public ICollection<TreeRelationship> TreeRelationshipTwo { get; set; }  
    }
}
