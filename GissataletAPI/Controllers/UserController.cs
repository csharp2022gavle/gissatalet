using Microsoft.AspNetCore.Mvc;
using User_Information_API.Models;
using User_Information_API.Services;

namespace User_Information_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService=userService;
        }
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            var user = userService.Get();
            return userService.Get();
        }
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user) 
        {
            userService.Create(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }
        [HttpGet("{id}")]
        public ActionResult<User> Get(string id) 
        {
            var user = userService.Get(id);

            if (user == null)
            {
                return NotFound($"User with ID = {id} not found");
            }
            return user;
        }
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] User user, string password) 
        {
            var existingUser = userService.Get(id);

            if (existingUser == null)
            {
                return NotFound($"User with ID = {id} not found");
            }
            bool correctPassword = false;
            correctPassword = Hashing.ValidatePassword(userService.Get(id).Password!, password);
            if (correctPassword == true)
            {
                userService.Update(id, user);
            }
            else if (correctPassword == false) 
            {
                return NotFound("Wrong password");
            }
            return NoContent();
        }
        //[HttpDelete("{id}")]
        //public ActionResult Delete(string id) 
        //{
        //    var user = userService.Get(id);

        //    if (user == null)
        //    {
        //        return NotFound($"User with ID = {id} not found");
        //    }

        //    userService.Remove(user.Id);

        //    return Ok($"User with Id = {id} deleted");
        //}
    }
}
