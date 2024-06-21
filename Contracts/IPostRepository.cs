using Entities.Models;

namespace Contracts
{
	public interface IPostRepository
	{
		IEnumerable<Post> GetPostsByUserId(int userId,bool trackChanges);
        Post GetPostByUserId(int userId, int postId, bool trackChanges);
        void CreatePostForUser(int userId,Post post);
		void DeletePost(Post post);
		
		
	}
}
