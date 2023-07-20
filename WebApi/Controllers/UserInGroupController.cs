using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class UserInGroupController : MainController
    {
        private readonly IUserInGroupService _userInGroupService;
        
        public UserInGroupController(IUserInGroupService userInGroupService)
        {
            _userInGroupService = userInGroupService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToGroup(Guid userId, Guid groupId)
        {
            var create = await _userInGroupService.AddUserToGroup(userId, groupId);
            if (create != null)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
