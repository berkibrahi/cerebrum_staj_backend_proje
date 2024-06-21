using AutoMapper;
using Contracts;
using Entities.Exceptionn;
using Entities.Models;
using ServiceContracts;
using Shared.DataTransferObjects;

namespace Service
{
	public class UserService : IUserService
	{
		private readonly IRepositorMenager _repository;
		private readonly ILoggerMenager _logger;
		private readonly IMapper _mapper;

		public UserService(IRepositorMenager repository, ILoggerMenager logger,IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}

        public UserDto CreateOneUser(UserDtoForCreation userDto)
        {
            //Dto -> entity
            	var entity = _mapper.Map<User>(userDto);
            	// repo ->save
            	_repository.User.CreateUser(entity);
            	_repository.Save();
            	//entity->Dto
            	return _mapper.Map<UserDto>(entity);
        }

        public IEnumerable<UserDto> DeleteAllUsers(bool trackChanges)
        {
            var users = _repository.User.GetAllUsers(trackChanges).ToList();
            foreach (var user in users)
            {
                _repository.User.DeleteUser(user);
            }
            _repository.Save();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public UserDto DeleteUser(int userId)
        {
            var user = _repository.User.GetOneUserById(userId, trackChanges: false);
            if (user == null)
                throw new UserNotFoundExceptions(userId);

            _repository.User.DeleteUser(user);
            _repository.Save();

            return _mapper.Map<UserDto>(user);
        
    
}
public IEnumerable<UserDto> GetAllUsers(bool trackChanges)
        {
            var users = _repository.User.GetAllUsers(trackChanges);
            		var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            		return userDtos;
        }

        public UserDto GetOneUserById(int userId, bool trackChanges)
        {
            		var user= _repository.User.GetOneUserById(userId, trackChanges);
            	if (user == null)
            		throw new UserNotFoundExceptions(userId);
            		var userDto = _mapper.Map<UserDto>(user);
            		return userDto;
        }

        public UserDto UpdateUser(int userId, UserDtoForUpdate userDto)
        {  // Önce mevcut kullanıcıyı bul
            var userEntity = _repository.User.GetOneUserById(userId, trackChanges: false);
            if (userEntity == null)
            {
                throw new UserNotFoundExceptions(userId);
            }

            // DTO'dan gelen verileri mevcut kullanıcıya kopyala
            _mapper.Map(userDto, userEntity);

            // Güncellenmiş kullanıcıyı veritabanına kaydet
            _repository.User.UpdateUser(userEntity);
            _repository.Save();

            // Güncellenmiş kullanıcıyı geri döndür
            var userToReturn = _mapper.Map<UserDto>(userEntity);
            return userToReturn;
        }
    }


}


