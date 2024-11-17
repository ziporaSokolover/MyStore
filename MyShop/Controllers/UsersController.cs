using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//שרה שלום וברכה לא סימנו הפונקצית עדכון עדיין בעדכון:) והפונקצית כניסה לא עובדת לנו משום מה ישבנו על זה הרבה זמן נשמח אם תצליחי לעזור תודה רבה!!!!! יום טוב!!!
namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserServices service;

        public UsersController(IUserServices service)
        {
            this.service = service;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            user = service.Post(user);
            if (user != null)
            {
                return Ok(user);
            }




            return NoContent();


        }

        //[HttpPost("login")]
        [HttpPost]
        [Route("Login")]

        public ActionResult Login([FromQuery] string email, [FromQuery] string password)
        {
            User user=service.Login(email, password);
            if (user!=null)
            {
                return Ok(user);
            }

                       
            return NoContent();



        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)

        {
           
            user = service.Put(id, user);
            if (user != null)
            {
                return Ok(user);
            }




            return NoContent();


            
            
            
        }
        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpPost("password")]
      
        public IActionResult cheackPassword([FromBody] string password)
        {
            int result = service.cheackPassword(password);
            return(result<3) ?
                   BadRequest(result):
            Ok( result);
        }

    }
}
