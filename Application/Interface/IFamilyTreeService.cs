using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
	public interface IFamilyTreeService
	{
		Task<bool> CreateFamilyTree(string treeName);
		Task<List<FamilyTree>> SearchFamilyTreeByName(string name);
		public Task<bool> SoftRemoveFamilyTreeAsync(string familyTreeId);
		public Task<FamilyTree> GetFamilyTreeByIdAsync(string familyTreeId);
    }
}
