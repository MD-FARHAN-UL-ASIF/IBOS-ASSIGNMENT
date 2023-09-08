using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmpController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var data = EmpService.Get();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("Employee not found");
            }
        }

        [HttpPost]
        public IActionResult Create(EmpDTO employeeDTO)
        {
            var data = EmpService.Create(employeeDTO);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("Please try again");
            }
        }

        [HttpPut]
        public IActionResult Update(int id, EmpDTO employeeDTO)
        {
            employeeDTO.EmployeeId = id;

            var isSuccess = EmpService.Update(employeeDTO);

            if (isSuccess)
            {
                return Ok("Updated ツ");
            }
            else
            {
                return BadRequest("Please try again ☹");
            }
        }

    }
}
