using Application.Interface;
using Application.InterfaceRepository;
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
        public FamilyTreeService (IFamilyTreeRepository familyTreeRepository, IUnitOfWork unitOfWork, IClaimService claimService, ICurrentTime currentTime)
		{
			_familyTreeRepository = familyTreeRepository;
			_unitOfWork = unitOfWork;
			_claimService = claimService;
			_currentTime = currentTime;
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
	}
}
