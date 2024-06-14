using CadUsers.Entities.DTOs;

namespace CadUsers.Business.UsersService
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task RegisterUserAsync(UserDto userDto);
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(int id);
        Task<UserDto> AuthenticateUserAsync(string login, string password);
    }
}