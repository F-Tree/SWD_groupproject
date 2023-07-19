using Application.Interface;
using Application.ViewModel.PersonViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IClaimService _claimService;

        public PersonController(IPersonService personService, IClaimService claimService)
        {
            _personService = personService;
            _claimService = claimService;
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePerson(UpdatePersonDTO updateObject, Guid id)
        {
            var result = await _personService.UpdatePersonInformation(updateObject, id);
            if (result) return Ok();
            else return BadRequest("Something went wrong");
        }
    }
}
