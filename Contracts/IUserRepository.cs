using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface IUserRepository
	{
		IEnumerable<User> GetAllUsers(bool trackChanges);
		User GetOneUserById(int userId,bool trackChanges);
		void CreateUser(User user);
		void DeleteUser(User user);

        void UpdateUser(User user);


    }
}
