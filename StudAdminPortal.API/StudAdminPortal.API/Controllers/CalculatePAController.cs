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
        [Route("GetOccupation")]
        public List<Occupation> GetOccupation()
        {
            return new List<Occupation>
            {
                new Occupation() { Occupationame = "Cleaner", Rating = "Light Manual" },
                new Occupation() { Occupationame = "Doctor", Rating = "Professional" },
                new Occupation() { Occupationame = "Author", Rating = "White Collar" },
                new Occupation() { Occupationame = "Farmer", Rating = "Heavy Manual" },
                new Occupation() { Occupationame = "Mechanic", Rating = "Heavy Manual" },
                new Occupation() { Occupationame = "Florist", Rating = "Light Manual" },
            }  ;
              
           
        }

        [HttpPost()]
        [Route("MonthlyPremiumCalculate")]
        public IActionResult MonthlyPremiumCalculate([FromBody] Employee employee)
        {
            double factor = 0;
            getfactor(employee.occupation, ref factor);
            double DeathPremium = (employee.deathSumInsured *factor* employee.age) / 1000 * 12;
            var emp = new PremiumCalculationResponse(){
              
                firstname=employee.firstname,
                lastname=employee.lastname,
                premiumAmount=DeathPremium,
               
            };
          
            return Json(emp);
        }

        private void getfactor(string occupation, ref double factor)
        {
            switch (occupation)
            {
                case "Professional":
                    {
                        factor = 1.0;
                        break;
                    }
                case "White Collar":
                    {
                        factor = 1.25;
                        break;
                    }
                case "Light Manual":
                    {
                        factor = 1.50;
                        break;
                    }
                case "Heavy Manual":
                    {
                        factor = 1.75;
                        break;
                    }
                default:
                    {
                        factor = 0;
                        break;
                    }

            }
        }
    }
}
