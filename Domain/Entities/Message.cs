using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }
        public Guid? GroupId { get; set; }
        public GroupChatEntity Group { get; set; }
    }
}
