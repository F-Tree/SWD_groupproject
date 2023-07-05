using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class FamilyTreeController : MainController
    {
        private readonly IFamilyTreeService _familyTreeService;
        public FamilyTreeController(IFamilyTreeService familyTreeService)
        {
            _familyTreeService = familyTreeService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateFamilyTreeAsync()
        {
            bool isCreated = await _familyTreeService.CreateTreeAsync();
            if (isCreated)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
