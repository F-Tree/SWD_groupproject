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
		public ICollection<User> Users { get; set; }
		public ICollection<Message> Messages { get; set; }	
    }
}
