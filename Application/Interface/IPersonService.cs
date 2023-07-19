using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;
using Application.ViewModel.PersonViewModel;

namespace Application.Interface
{
    public interface IPersonService
    {
        public Task<bool> UpdatePersonInformation(UpdatePersonDTO updatePerson, Guid id);
    }
}
