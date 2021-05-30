using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.models;
using Ecommerce.services.interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.controllers.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            try
            {
                IEnumerable<User> users = this._userService.GetAll();
                return Ok(users);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            try
            {
                User user = this._userService.GetById(id);
                return Ok(user);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("")]
        public ActionResult<User> PostUser(User newUser)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User updatedUser)
        {
            try
            {
                User user = this._userService.GetById(id);
                user = updatedUser;
                this._userService.Update(user);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUserById(int id)
        {
            try
            {
                this._userService.Delete(id);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}