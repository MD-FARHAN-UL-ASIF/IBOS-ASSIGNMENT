using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonthlyController : Controller
    {
        [HttpGet("monthly_attendance")]
        public IActionResult GetMonthlyReport()
        {
            var monthlyService = new MonthlyAttService();
            var data = monthlyService.GetMonthlyReport();

            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("SHhhhhhhh, You lost!");
            }
        }
    }
}
