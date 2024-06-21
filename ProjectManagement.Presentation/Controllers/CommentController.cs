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
    [Route("api/posts/{postId}/comments")]
    public class CommentController : ControllerBase
    {

        
      
            private readonly IServiceManager _service;

            public CommentController(IServiceManager service)
            {
                _service = service;
            }
            [HttpGet]
            public IActionResult GetAllCommentUserAndPostById(int postId)
            {

                var commentlist = _service.CommentService.GetAllCommentsByUserAndIdPostId( postId, false);
                return Ok(commentlist);


            }
            [HttpGet("{commentId}", Name = "GetOneCommentByPostIdAndcommentId")]
            public IActionResult GetoneCommentPostAndUserById( int postId, int commentId)
            {


                var comment = _service.CommentService.GetoneCommentPostUserById(postId, commentId, false);
                return Ok(comment);


            }
            [HttpPost]
            public IActionResult CreateoneCommentPostById(int postId, [FromBody] CommentDtoForCreation commentDto)
            {

                CommentDto comment = _service.CommentService.CreateoneCommentPostAndUserById( postId, commentDto, true);

                return CreatedAtRoute("GetOneCommentByPostIdAndcommentId", new {  postId, commentId = comment.CommentId }, comment);
            }
        }
    }


