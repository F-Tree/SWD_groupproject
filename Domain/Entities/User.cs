using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class User:BaseEntity
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; }
        public string? Name { get; set; }
        [ForeignKey("Role")]
        public int? RoleId { get; set; } 
        public string? RefreshToken { get; set; }
        public string? AccessToken { get; set; }
        public string? PhoneNumber { get; set; }
        public Role Role { get; set; }
        [ForeignKey("FamilyGroup")]
        public Guid? FamilyGroupId { get; set; }
        public FamilyGroup FamilyGroup { get; set; }
    }
}
