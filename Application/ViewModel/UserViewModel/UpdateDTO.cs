using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.UserViewModel
{
    public class UpdateDTO
    {     
        public string UserName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
