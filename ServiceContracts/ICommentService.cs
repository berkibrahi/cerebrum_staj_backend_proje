using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface ICommentService
    {
        CommentDto CreateoneCommentPostAndUserById(int postId, CommentDtoForCreation commentDto, bool trackChanges);
        IEnumerable<CommentDto> GetAllCommentsByUserAndIdPostId(int postId, bool trackChanges);
        CommentDto GetoneCommentPostUserById(int postId, int commentId, bool trackChanges);
    }
}
