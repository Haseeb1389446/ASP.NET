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


        // Example 2

        // [HttpPost]
        // public string GetUserName([FromForm] string Name)
        // {
        //     return $"User Name Is {Name}";
        // }


        // Example 3

        // [HttpGet]
        // public List<string> GetUserArray()
        // {
        //     return ["User Name Is: Haseeb", "User Age Is: 15", "User Email Is: haseeb@gmail.com", "User Name Is: +92 33 3333333"];
        // }
    }
}
