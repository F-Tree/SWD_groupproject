using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities
{
	public class UserInGroup
	{
		public Guid? UserId { get; set; }
		public Guid? GroupId { get; set; }
		public int? GroupRoleId { get; set; }	
		public DateTime? JoinedDate { get; set; }
		public DateTime? BannedDate { get; set; }
		public bool isBanned { get; set; }
		public User User { get; set; }
		public FamilyGroup FamilyGroup { get; set; }
		public GroupRole GroupRole { get; set; }
	}
}
