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
	public class FamilyTreeService : ITreeService
	{
		private readonly IFamilyTreeRepository _familyTreeRepository;
		public FamilyTreeService (IFamilyTreeRepository familyTreeRepository)
		{
			_familyTreeRepository = familyTreeRepository;
		}
		public async Task<List<FamilyTree>> SearchFamilyTreeByName(string name)
		{
			return await _familyTreeRepository.SearchFamilyTree(name);
		}
	}
}
