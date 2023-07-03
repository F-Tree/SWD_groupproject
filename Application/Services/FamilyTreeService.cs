using Application.Interface;
using Application.InterfaceRepository;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FamilyTreeService : IFamilyTreeService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimService _claimService;
        private readonly IConfiguration _configuration;
        private readonly ICurrentTime _currentTime;
        public FamilyTreeService(IFamilyTreeRepository familyTreeRepository, IClaimService claimService, IUnitOfWork unitOfWork, ICurrentTime currentTime, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _claimService = claimService;
            _currentTime = currentTime;
            _configuration = configuration;
        }

        public async Task<bool> CreateTreeAsync()
        {
            FamilyTree tree = new FamilyTree();
            tree.CreatedBy = _claimService.GetCurrentUserId;
            tree.ModificationBy = _claimService.GetCurrentUserId;
            tree.ModificationDate = DateTime.Now;
            await _unitOfWork.FamilyTreeRepository.AddAsync(tree);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
