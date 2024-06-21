using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class PostRepository : RepositoryBase<Post>, IPostRepository
	{
		public PostRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
			
		}

        public void CreatePostForUser(int userId, Post post)
        {
            post.UserId = userId;
            Create(post);
        }

        public void DeletePost(Post post)
        {
            Delete(post);
        }

        public Post GetPostByUserId(int userId, int postId, bool trackChanges)
        {
            return FindByCondition(p => p.UserId.Equals(userId) && p.PostId.Equals(postId), trackChanges).SingleOrDefault();
        }
        public IEnumerable<Post> GetPostsByUserId(int userId, bool trackChanges)=>
            FindByCondition(p => p.UserId.Equals(userId), trackChanges).OrderBy(p => p.Title).ToList();

       

    }
}
