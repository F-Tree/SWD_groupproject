using Application.Interface;
using Application.ViewModel.PersonViewModel;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PersonController : MainController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }      

        [HttpPut]
        //role FamilyAdmin
        public async Task<IActionResult> UpdatePerson(UpdatePersonDTO updateObject, Guid id)
        {
            var result = await _personService.UpdatePersonInformation(updateObject, id);
            if (result) return Ok();
            else return BadRequest("Something went wrong");
        }

        [HttpDelete]
        /*[Authorize]
        [ClaimRequirement(nameof(PermissionItem.ClassPermission), nameof(PermissionEnum.Modifed))]*/
        public async Task<IActionResult> SoftRemovePerson(string personId)
        {
            try
            {
                if (await _personService.SoftRemovePersonAsync(personId))
                {
                    return Ok("SoftRemove person successfully");
                }
                else
                {
                    throw new Exception("Saving failed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("SoftRemove person failed: " + ex.Message);
            }
        }
    }
}
