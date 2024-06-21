using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCommentForPostanUser( int postId, Comment comment)
        {
           
            comment.PostId = postId;
            Create(comment);
        }

        public void DeleteComment(Comment comment)
        {
            Delete(comment);
        }

        public Comment GetCommentByPostanUserId( int postId, int commentId, bool trackChanges)
        {
            return FindByCondition(c => c.PostId.Equals(postId) && c.CommentId.Equals(commentId) , trackChanges).SingleOrDefault();
        }

        public IEnumerable<Comment> GetCommentsByPostandUserId( int postId, bool trackChanges)
        {
            return FindByCondition(c=> c.PostId == postId, trackChanges)
           .OrderBy(c => c.Content)
           .ToList();
        }
    }
    }
