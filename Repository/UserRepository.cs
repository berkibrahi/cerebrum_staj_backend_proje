using Contracts;
using Entities.Exceptionn;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class UserRepository : RepositoryBase<User>, IUserRepository
	{
		public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

        public void CreateUser(User user) => Create(user);


        public void DeleteUser(User user) => Delete(user);
       

        public IEnumerable<User> GetAllUsers(bool trackChanges)=>
        FindAll(trackChanges).
        	OrderBy(u=>u.Name).ToList();



        public User GetOneUserById(int userId, bool trackChanges)
      {
    var user = FindByCondition(u => u.UserId.Equals(userId), trackChanges)
                   .SingleOrDefault();

    if (user == null)
    {
                throw new UserNotFoundExceptions(userId);
    }

    return user;
}

public void UpdateUser(User user) => Update(user);
         
    }
        

}

