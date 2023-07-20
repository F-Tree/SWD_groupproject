using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;
using Application.ViewModel.PersonViewModel;
using Domain.Entities;

namespace Application.Interface
{
    public interface IPersonService
    {
        public Task<bool> UpdatePersonInformation(UpdatePersonDTO updatePerson, Guid id);
        public Task<Person> GetPersonByIdAsync(string personId);
        public Task<bool> SoftRemovePersonAsync(string personId);
    }
}
