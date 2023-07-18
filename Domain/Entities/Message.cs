using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Message : BaseEntity
    {
        public string Content { get; set; }
        public Guid? GroupId { get; set; }
        public FamilyGroup Group { get; set; }
    }
}
