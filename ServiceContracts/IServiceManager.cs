using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
	public interface IServiceManager
	{
		public IUserService UserService { get; }
		public IPostService PostService { get; }
        public ICommentService CommentService { get; }
    }
}
