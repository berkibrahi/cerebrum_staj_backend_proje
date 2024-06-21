using AutoMapper;
using Contracts;
using Entities.Exceptionn;
using Entities.Models;
using ServiceContracts;
using Shared.DataTransferObjects;

namespace Service
{
	public class PostService : IPostService
	{
		private readonly IRepositorMenager _repository;
		private readonly ILoggerMenager _logger;
		private readonly IMapper _mapper;

		public PostService(IRepositorMenager repository, ILoggerMenager logger,IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}

        public PostDto CreateonePostUserById(int userId, PostDtoForCreation postDto, bool trackChanges)
        {
            var user = _repository.User.GetOneUserById(userId, false);
                     if (user == null)
                      throw new UserNotFoundExceptions(userId);
                      var entity = _mapper.Map<Post>(postDto);
            	entity.UserId = userId;
                      // repo ->save
                     _repository.Post.CreatePostForUser(userId,entity);
                      _repository.Save();
                      //entity->Dto
                      return _mapper.Map<PostDto>(entity);
        }

        public PostDto DeletePost(int userId,int postId)
        {
            var post = _repository.Post.GetPostByUserId(userId, postId, trackChanges: false);
            if (post == null)
                throw new PostNotFoundExceptions(userId);

            _repository.Post.DeletePost(post);
            _repository.Save();

            return _mapper.Map<PostDto>(post);
        }

        public IEnumerable<PostDto> GetAllPostsByUserId(int userId, bool trackChanges)
        {
            CheckUserExists(userId);
                     var postlist = _repository.Post.GetPostsByUserId(userId, trackChanges);
            	var postlistDtos = _mapper.Map<IEnumerable<PostDto>>(postlist);
            	return postlistDtos;
        }



        public PostDto GetonePostUserById(int userId, int postId, bool trackChanges)
        {
            CheckUserExists(userId); // Kullanıcının varlığını kontrol et

            var post = _repository.Post.GetPostByUserId(userId, postId, trackChanges); // Kullanıcıya ait gönderiyi getir
            if (post == null)
                throw new PostNotFoundExceptions(postId); // Gönderi bulunamazsa PostNotFoundException hatası fırlat

            var postDto = _mapper.Map<PostDto>(post); // Entity'i DTO'ya dönüştür
            return postDto;
        }

        
        private void CheckUserExists(int userId)
        {
                 var user = _repository.User.GetOneUserById(userId,  false);
                 if (user == null)
                     throw new UserNotFoundExceptions(userId);
             }
    }
}
