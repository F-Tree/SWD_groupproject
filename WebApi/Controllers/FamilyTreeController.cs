using Application.Interface;
using Application.Services;
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

        [HttpDelete]
        /*[Authorize]
        [ClaimRequirement(nameof(PermissionItem.ClassPermission), nameof(PermissionEnum.Modifed))]*/
        public async Task<IActionResult> SoftRemoveFamilyTree(string familyTreeId)
        {
            try
            {
                if (await _treeService.SoftRemoveFamilyTreeAsync(familyTreeId))
                {
                    return Ok("SoftRemove tree successfully");
                }
                else
                {
                    throw new Exception("Saving failed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("SoftRemove tree failed: " + ex.Message);
            }
        }
    }
}
