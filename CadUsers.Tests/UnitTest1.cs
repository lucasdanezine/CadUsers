using AutoMapper;
using CadUsers.API.MappingProfiles;
using CadUsers.Business.UsersService;
using CadUsers.Entities.DTOs;
using CadUsers.Entities.Models;
using CadUsers.Repository;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace CadUsers.Tests
{
    public class UserServiceTests
    {
        private readonly IUserService _userService;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly IMapper _mapper;
        private readonly Mock<IPasswordHasher<User>> _passwordHasherMock;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = configuration.CreateMapper();

            // Configurando o mock para IPasswordHasher<User>
            _passwordHasherMock = new Mock<IPasswordHasher<User>>();
            _userService = new UserService(_userRepositoryMock.Object, _mapper, _passwordHasherMock.Object);
        }

        [Fact]
        public async Task ValidateRegisterUser()
        {
            // Arrange
            var userDto = new UserDto { Name = "Test", Email = "test@test.com", UserName = "test", Password = "password" };

            // Configurando o comportamento do mock de passwordHasher para retornar uma senha hasheada
            _passwordHasherMock.Setup(p => p.HashPassword(It.IsAny<User>(), It.IsAny<string>()))
                               .Returns((User u, string password) => password); // Simplesmente retorna a senha como está para efeito de teste

            // Act
            await _userService.RegisterUserAsync(userDto);

            // Assert
            _userRepositoryMock.Verify(r => r.AddUserAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
