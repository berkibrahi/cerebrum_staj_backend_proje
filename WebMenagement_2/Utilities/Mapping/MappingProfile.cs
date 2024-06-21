using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace WebMenagement_2.Utilities.Mapping
{
	public class MappingProfile :Profile
	{
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<UserDtoForCreation, User>();
            CreateMap<PostDtoForCreation, Post>();
            CreateMap<CommentDtoForCreation, Comment>();
            CreateMap<User, UserDto>().ReverseMap(); ;
            CreateMap<UserDtoForUpdate, User>();

        }
    }
}
