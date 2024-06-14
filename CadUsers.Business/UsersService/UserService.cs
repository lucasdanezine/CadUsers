using AutoMapper;
using Microsoft.AspNetCore.Identity;
using CadUsers.Entities.DTOs;
using CadUsers.Entities.Models;
using CadUsers.Repository;

namespace CadUsers.Business.UsersService
{


    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task RegisterUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Password = _passwordHasher.HashPassword(user, user.Password); // Hashing the password
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<UserDto> AuthenticateUserAsync(string login, string password)
        {
            var user = await _userRepository.GetUserByLoginAsync(login);
            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.Password, password) == PasswordVerificationResult.Failed)
                return null;

            return _mapper.Map<UserDto>(user);
        }
    }
}
