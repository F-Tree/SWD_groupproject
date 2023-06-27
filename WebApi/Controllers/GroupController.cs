using Application.Interface;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class GroupController : MainController
    {
        private readonly IGroupService _groupService;
        private readonly IClaimService _claimService;

        public GroupController(IGroupService groupService, IClaimService claimService)
        {
            _groupService = groupService;
            _claimService = claimService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateGroupAsync(string groupName, string groupDesc)
        {
            bool isCreated = await _groupService.CreateGroupAsync(groupName, groupDesc);
            if (!isCreated)
            {
                return BadRequest();
            }
            return Ok();
        } 
    }
}
