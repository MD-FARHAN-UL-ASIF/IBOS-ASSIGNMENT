using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmpController : Controller
    {
        [HttpGet("employee_list")]
        public IActionResult Get()
        {
            var data = EmpService.Get();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("where are you?");
            }
        }

        [HttpPost("add_employee")]
        public IActionResult Create(EmpDTO employeeDTO)
        {
            var data = EmpService.Create(employeeDTO);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("ops...! try again");
            }
        }

        [HttpPut("update_employee/{id}")]
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
                return BadRequest("will you try again ☹..?");
            }
        }

        [HttpGet("third_highest_salary")]
        public IActionResult ThirdHighestSal()
        {
            var data = EmpService.Get3rd();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("ops...we cant find!");
            }
        }

        [HttpGet("Abcent")]
        public IActionResult GetOnAbcent()
        {
            var data = EmpService.GetOnAbsent();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("Record Not Found!");
            }
        }

        [HttpGet("employee_supervisor/{id}")]
        public IActionResult GetByHierarchy(int id)
        {
            var data = EmpService.GetEmployeeHierarchy(id);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("we cant find you!");
            }
        }
    }
}
