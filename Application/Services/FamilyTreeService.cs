using Application.Interface;
using Application.InterfaceRepository;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class FamilyTreeService : IFamilyTreeService
	{
		private readonly IFamilyTreeRepository _familyTreeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimService _claimService;
        private readonly ICurrentTime _currentTime;
        private readonly IMapper _mapper;
        public FamilyTreeService (IFamilyTreeRepository familyTreeRepository, IUnitOfWork unitOfWork, IClaimService claimService, ICurrentTime currentTime, IMapper mapper)
		{
			_familyTreeRepository = familyTreeRepository;
			_unitOfWork = unitOfWork;
			_claimService = claimService;
			_currentTime = currentTime;
            _mapper = mapper;
		}

        public async Task<bool> CreateFamilyTree(string treeName)
        {
			var familyTree = new FamilyTree
			{
				CreationDate = _currentTime.GetCurrentTime(),
				CreatedBy = _claimService.GetCurrentUserId,
				ModificationDate = _currentTime.GetCurrentTime(),
				ModificationBy = _claimService.GetCurrentUserId,
				TreeName = treeName
			};
			await _unitOfWork.FamilyTreeRepository.AddAsync(familyTree);
			return await _unitOfWork.SaveChangeAsync() > 0;

        }

        public async Task<List<FamilyTree>> SearchFamilyTreeByName(string name)
		{
			return await _familyTreeRepository.SearchFamilyTree(name);
		}

        public async Task<bool> SoftRemoveFamilyTreeAsync(string familyTreeId)
        {
            var familyTreeObj = await GetFamilyTreeByIdAsync(familyTreeId);

            _familyTreeRepository.SoftRemove(familyTreeObj);
            return (await _unitOfWork.SaveChangeAsync() > 0);
        }

        public async Task<FamilyTree> GetFamilyTreeByIdAsync(string familyTreeId)
        {
            try
            {
                var _familyTreeId = _mapper.Map<Guid>(familyTreeId);
                var familyTreeObj = await _familyTreeRepository.GetByIdAsync(_familyTreeId);
                return familyTreeObj ?? throw new NullReferenceException($"Incorrect Id: The person with id: {familyTreeId} doesn't exist or has been deleted!");
            }
            catch (AutoMapperMappingException)
            {
                throw new AutoMapperMappingException("Incorrect Id!");
            }
        }
    }
}
