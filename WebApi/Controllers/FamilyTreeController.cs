using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FamilyTreeController : MainController
	{
		private readonly ITreeService _treeService;
		public FamilyTreeController (ITreeService treeService)
		{
			_treeService = treeService;
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
