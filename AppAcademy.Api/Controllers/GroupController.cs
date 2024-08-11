using AppAcademy.Application.Dtos.GroupDtos;
using AppAcademy.Application.Exceptions;
using AppAcademy.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppAcademy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost("")]
        public IActionResult Create(GroupCreateDto groupCreateDto)
        {
            try
            {
                return Ok(_groupService.Create(groupCreateDto));
            }
            catch (DublicateEntityException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Xeta bash verdi");
            }
        }


        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(_groupService.GetAll());
        }
    }
}
