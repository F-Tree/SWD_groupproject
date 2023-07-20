using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[ApiController]
	public class FamilyTreeController : MainController
	{
		private readonly IFamilyTreeService _treeService;
		public FamilyTreeController (IFamilyTreeService treeService)
		{
			_treeService = treeService;
		}
		[Authorize]
		[HttpPost]
		public async Task<IActionResult> CreateFamilyTree(string treeName)
		{
			var isSucceed = await _treeService.CreateFamilyTree(treeName);
			if (!isSucceed)
			{
				return BadRequest("Create tree fail!");
			}
			return Ok("Create tree succeed!");
		}
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> SearchFamilyTreeByName(string name)
		{
			var tree=await _treeService.SearchFamilyTreeByName(name);
			if (tree == null)
			{
				return NotFound();
			}
			return Ok(tree);
		}
	}
}
