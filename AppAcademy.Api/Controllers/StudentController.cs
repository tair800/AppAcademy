using AppAcademy.Application.Dtos.StudentDtos;
using AppAcademy.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppAcademy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("")]
        public IActionResult Create(StudentCreateDto studentCreateDto)
        {
            try
            {
                return Ok(_studentService.Create(studentCreateDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
