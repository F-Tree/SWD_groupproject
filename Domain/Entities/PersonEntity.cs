using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PersonEntity : BaseEntity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }
        public string BirthPlace { get; set; }
        public string DeathPlace { get; set; }
        public bool Status { get; set; }
        public bool Gender { get; set; }
        public Guid FatherID { get; set; }
        public Guid MotherID { get; set; }
        public Guid SpouseID { get; set; }

    }
}
