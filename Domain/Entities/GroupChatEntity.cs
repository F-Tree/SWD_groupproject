using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GroupChatEntity : BaseEntity
    {
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
