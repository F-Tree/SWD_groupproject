using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FamilyGroup : BaseEntity
    {
		public string GroupName { get; set; }
		public string GroupDescription { get; set; }
		public int MemberAmount { get; set; }
		public ICollection<Message> Messages { get; set; }	
		public ICollection<UserInGroup> UserInGroups { get; set; }
    }
}
