using Microsoft.AspNetCore.Mvc;
using StudAdminPortal.API.DataModels;

namespace StudAdminPortal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatePAController : Controller
    {
        public CalculatePAController()
        {

        }
       
        [HttpGet()]
        [Route("MonthlyPremiumCalculate")]
        public IActionResult MonthlyPremiumCalculate([FromBody] Employee employee)
        {
           int _MOER = 32;
            double DeathPremium = (employee.deathSumInsured * employee.age) / 1000 * 12;
            return Json(_MOER);
        }
    }
}
