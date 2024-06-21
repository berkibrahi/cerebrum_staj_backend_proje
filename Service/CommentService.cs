using AutoMapper;
using Contracts;
using Entities.Exceptionn;
using Entities.Models;
using ServiceContracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CommentService : ICommentService
    {

        private readonly IRepositorMenager _repository;
        private readonly ILoggerMenager _logger;
        private readonly IMapper _mapper;

        public CommentService(IRepositorMenager repository, ILoggerMenager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public CommentDto CreateoneCommentPostAndUserById( int postId, CommentDtoForCreation commentDto, bool trackChanges)
        {
            CheckPostAndUserExists(postId);
            var entity = _mapper.Map<Comment>(commentDto);
            entity.PostId = postId;
           
            // repo ->save
            _repository.Comment.CreateCommentForPostanUser(postId, entity);
            _repository.Save();
            //    //entity->Dto
            return _mapper.Map<CommentDto>(entity);
        }




        public IEnumerable<CommentDto> GetAllCommentsByUserAndIdPostId( int postId, bool trackChanges)
        {
            CheckPostAndUserExists(postId);
            var commentlist = _repository.Comment.GetCommentsByPostandUserId( postId, trackChanges);
            var commentlistDtos = _mapper.Map<IEnumerable<CommentDto>>(commentlist);
            return commentlistDtos;
        }

        public CommentDto GetoneCommentPostUserById(int postId, int commentId, bool trackChanges)
        {
            CheckPostAndUserExists(postId);
            var comment = _repository.Comment.GetCommentByPostanUserId(postId, commentId, trackChanges);
            if (comment == null)
                throw new CommentNotFoundExceptions(postId);
            var commentDto = _mapper.Map<CommentDto>(comment);
            return commentDto;
        }





        private void CheckPostAndUserExists(int postId)
        {


            var post = _repository.Post.GetPostsByUserId(postId, false);
            if (post == null)
                throw new PostNotFoundExceptions(postId);

        }
    }
}
