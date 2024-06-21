using AutoMapper;
using Contracts;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public class ServiceManager : IServiceManager
	{
		private readonly Lazy<IUserService> _userService;
		private readonly Lazy<ICommentService> _commentService;
        private readonly Lazy<IPostService> _postService;
        public ServiceManager(IRepositorMenager repository,ILoggerMenager logger,IMapper mapper)
        {
            _userService = new Lazy<IUserService>(()=>new UserService(repository,logger,mapper));
			_postService = new Lazy<IPostService>(() => new PostService(repository, logger,mapper));
            _commentService = new Lazy<ICommentService>(() => new CommentService(repository, logger, mapper));
        }
        public IUserService UserService => _userService.Value;

		public IPostService PostService => _postService.Value;
        public ICommentService CommentService => _commentService.Value;
	}
}
