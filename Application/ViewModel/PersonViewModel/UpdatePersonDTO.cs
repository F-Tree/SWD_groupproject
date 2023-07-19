using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.PersonViewModel
{
    public class UpdatePersonDTO
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; } // Alive, Deceased, ...
        public DateTime? DateOfDeath { get; set; }
        public string? RestingPlace { get; set; }
    }
}
