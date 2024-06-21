using Entities.Models;

using Shared.DataTransferObjects;

namespace ServiceContracts
{
	public interface IUserService
	{
        UserDto CreateOneUser(UserDtoForCreation userDto);
        IEnumerable<UserDto> GetAllUsers(bool trackChanges);
		UserDto GetOneUserById(int userId, bool trackChanges);
        IEnumerable <UserDto> DeleteAllUsers(bool trackChanges);
        UserDto DeleteUser(int userId);
        UserDto UpdateUser(int userId, UserDtoForUpdate userDto);
    }
}
