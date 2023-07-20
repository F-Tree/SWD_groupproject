using Application.Interface;
using Application.InterfaceRepository;
using Application.ViewModel.PersonViewModel;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ICurrentTime _currentTime;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;

        public PersonService(IPersonRepository personRepository, IUnitOfWork unitOfWork, ICurrentTime currentTime, IConfiguration configuration, IMapper mapper, IClaimService claimService)
        {
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
            _currentTime = currentTime;
            _configuration = configuration;
            _mapper = mapper;
            _claimService = claimService;
        }

        public async Task<bool> UpdatePersonInformation(UpdatePersonDTO updatePerson, Guid id)
        {
            if (updatePerson != null)
            {                
                Person person = await _personRepository.GetByIdAsync(id);
                _ = _mapper.Map(updatePerson, person, typeof(UpdatePersonDTO), typeof(Person));

                _personRepository.Update(person);
                if (await _unitOfWork.SaveChangeAsync() > 0) return true;
                else return false;
            }
            throw new Exception("Person can not be null");
        }

        public async Task<Person> GetPersonByIdAsync(string personId)
        {
            try
            {
                var _personId = _mapper.Map<Guid>(personId);
                var personObj = await _personRepository.GetByIdAsync(_personId);
                return personObj ?? throw new NullReferenceException($"Incorrect Id: The person with id: {personId} doesn't exist or has been deleted!");
            }
            catch (AutoMapperMappingException)
            {
                throw new AutoMapperMappingException("Incorrect Id!");
            }
        }

        public async Task<bool> SoftRemovePersonAsync(string personId)
        {
            var personObj = await GetPersonByIdAsync(personId);

            _personRepository.SoftRemove(personObj);
            return (await _unitOfWork.SaveChangeAsync() > 0);
        }
    }
}
