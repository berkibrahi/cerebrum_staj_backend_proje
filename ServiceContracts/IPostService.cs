using Entities.Models;
using Shared.DataTransferObjects;

namespace ServiceContracts
{
	public interface IPostService
	{
        PostDto CreateonePostUserById(int userId, PostDtoForCreation postDto, bool trackChanges);
        IEnumerable<PostDto> GetAllPostsByUserId(int userId,bool trackChanges);
		PostDto GetonePostUserById(int userId,int postId, bool trackChanges);
        
        PostDto DeletePost(int userId,int postId);

    }
}
