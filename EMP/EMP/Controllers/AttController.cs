using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttController : Controller
    {
        [HttpGet("attendance_list")]
        public IActionResult Get()
        {
            var data = AttService.Get();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("Not Found");
            }
        }

        [HttpGet("attendance/{id}")]
        public IActionResult Get(int id)
        {
            var data = AttService.Get(id);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("Attendence Not Found");
            }
        }
        [HttpPost("add_attendance")]
        public IActionResult Create(EmpAttDTO attDTO)
        {
            var data = AttService.Create(attDTO);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("Try again");
            }
        }
    }
}
