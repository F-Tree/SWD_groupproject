using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.PersonViewModel
{
    public class CreatePersonDTO
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; } // Alive, Deceased, ...
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string? BirthPlace { get; set; }
        public string? RestingPlace { get; set; }
    }
}
