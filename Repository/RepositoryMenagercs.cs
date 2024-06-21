using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class RepositoryMenagercs : IRepositorMenager


	{
		private readonly RepositoryContext _context;
		private Lazy<IUserRepository> _userRepository;
		private Lazy<IPostRepository> _postRepository;
		private Lazy<ICommentRepository> _commentRepository;

		public RepositoryMenagercs(RepositoryContext context)
		{
			_context = context;
			_userRepository = new Lazy<IUserRepository>(()=>new UserRepository(_context));
			_postRepository = new Lazy<IPostRepository>(()=> new PostRepository(_context));
            _commentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(_context));
        }

        public IUserRepository User =>_userRepository.Value;

        public IPostRepository Post =>_postRepository.Value ;

        public ICommentRepository Comment =>_commentRepository.Value;

        public void Save()
		{
			_context.SaveChanges();
		}
	}
}
