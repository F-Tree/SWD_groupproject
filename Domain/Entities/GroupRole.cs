using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public  class GroupRole
	{
		public int GroupRoleId { get; set; }
		public string GroupRoleName { get; set; }
		public ICollection<UserInGroup> UserInGroups { get; set; }
	}
}
