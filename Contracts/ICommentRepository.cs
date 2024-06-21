using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetCommentsByPostandUserId( int postId, bool trackChanges);
        Comment GetCommentByPostanUserId(int postId, int commentId, bool trackChanges);
        void CreateCommentForPostanUser( int postId, Comment comment);
        void DeleteComment(Comment comment);
    }
}
