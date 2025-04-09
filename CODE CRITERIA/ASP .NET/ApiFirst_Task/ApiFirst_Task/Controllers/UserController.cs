using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirst_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Example 1

        [HttpGet]
        public string GetUser()
        {
            string Name = "Haseeb";
            string Age = "15";
            string Email = "haseeb@gmail.com";
            string Contact = "+92 33 333333";

            return $"User Name Is {Name} \n" +
                $"User Age Is {Age} \n" +
                $"User Email Is {Email} \n" +
                $"User Contact Is {Contact} \n";
        }

        public string GetUserName([FromForm] string Name)
        {
            return $"User Name Is {Name}";
        }
    }
}
