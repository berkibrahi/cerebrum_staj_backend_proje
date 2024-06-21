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
	[Route("api/users/{userId}/posts")]
	public class PostController:ControllerBase
	{
		private readonly IServiceManager _service;

		public PostController(IServiceManager service)
		{
			_service = service;
		}
		[HttpGet]
		public IActionResult GetAllPostUserById(int userId)
		{
			
				var postlist = _service.PostService.GetAllPostsByUserId(userId, false);
				return Ok(postlist);
			

		}
		[HttpGet("{postId}",Name ="GetOnePostByUserIdAndPostId")]
		public IActionResult GetonePostProjectById(int userId,int postId)
		{


            var user = _service.UserService.GetOneUserById(userId, trackChanges: false);
            return Ok(user);


        }
        [HttpPost]
        public IActionResult CreateonePostUserById(int userId, [FromBody]PostDtoForCreation postDto)
        {

			PostDto post = _service.PostService.CreateonePostUserById(userId, postDto, true);

			return CreatedAtRoute("GetOnePostByUserIdAndPostId", new { userId, postId = post.PostId }, post);
        }
        [HttpDelete("{postId}")]
        public IActionResult DeletePost(int userId,int postId)
        {
            var deletedPost = _service.PostService.DeletePost(userId,postId);
            return Ok(deletedPost);
        }
    }
}
