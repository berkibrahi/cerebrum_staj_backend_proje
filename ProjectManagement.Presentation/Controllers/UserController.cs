using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Presentation.Controllers
{
	[ApiController]
	[Route("api/Users")]
	public class UserController : ControllerBase
	{
		private readonly IServiceManager _service;

		public UserController(IServiceManager service)
		{
			_service = service;
		}
		[HttpGet]
		public IActionResult GetAllUsers()
		{

			var users = _service.UserService.GetAllUsers(false);
			return Ok(users);

		}
		[HttpGet("{userId}", Name = "UserById")]
		public IActionResult GetOneUserById(int userId)
		{

			var user = _service.UserService.GetOneUserById(userId, false);
			return Ok(user);

		}
		[HttpPost]
		public IActionResult CreatOneUser([FromBody] UserDtoForCreation userDto)
		{
			var user = _service.UserService.CreateOneUser(userDto);
			return CreatedAtRoute("UserById", new { userId = user.UserId }, User);
		}
		[HttpDelete]
		public IActionResult DeleteAllUsers()
		{

			var users = _service.UserService.DeleteAllUsers(false);
			return Ok(users);

		}
        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            var deletedUser = _service.UserService.DeleteUser(userId);
            return Ok(deletedUser);
        }
        [HttpPut("{userId}")] // Add this method
        public IActionResult UpdateUser(int userId, [FromBody] UserDtoForUpdate userDto)
        {
         
            var updatedUser = _service.UserService.UpdateUser(userId, userDto);
            return Ok(updatedUser);
        }

    }
}
