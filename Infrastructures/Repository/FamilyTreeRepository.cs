using Application.Interface;
using Application.InterfaceRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repository
{
	public class FamilyTreeRepository : GenericRepository<FamilyTree>, IFamilyTreeRepository
	{
		private AppDbContext _dbContext;
		public FamilyTreeRepository(AppDbContext dbContext, ICurrentTime timeService, IClaimService claimsService) : base(dbContext, timeService, claimsService)
		{
			_dbContext= dbContext;
		}

		public async Task<List<FamilyTree>> SearchFamilyTree(string name)
		{
			var familyTree= await _dbContext.FamilyTree.Where(x=>x.TreeName.Equals(name)).ToListAsync();
			return familyTree;
		}
	}
}
