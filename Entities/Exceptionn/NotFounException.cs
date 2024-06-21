using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptionn
{
    public class NotFounException : Exception
    {
        protected NotFounException(string message):base(message)
        {
        }
    }
    public sealed class UserNotFoundExceptions : NotFounException
    {
        public UserNotFoundExceptions(int userId) 
            : base($"bu user id: {userId} bulunamadı")
        {
        }
    }
    public sealed class PostNotFoundExceptions : NotFounException
    {
        public PostNotFoundExceptions(int postId)
            : base($"bu post id: {postId} bulunamadı")
        {
        }
    }
    public sealed class CommentNotFoundExceptions : NotFounException
    {
        public CommentNotFoundExceptions(int commentId)
            : base($"bu comment id: {commentId} bulunamadı")
        {
        }
    }
}
