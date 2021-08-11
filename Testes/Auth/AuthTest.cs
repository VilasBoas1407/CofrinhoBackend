using Domain.DTO;
using Domain.DTO.Login;
using Domain.Interfaces;
using Domain.Utils;
using Moq;
using Service.Utils;
using System;
using Xunit;

namespace Testes.Login
{
  
    public class AuthTest
    {
        private IAuthService authService;
        private Mock<IAuthService> mock;

        [Fact]
        public async void DeveRealizarLoginComEmailESenha()
        {
            //Arrange
            var userLogin = new LoginRequestDTO();
            userLogin.Email = Faker.Internet.Email();  
            userLogin.Password = new Hash().CriptografarSenha("123456");

            var result = new LoginResponseDTO();
            result.Name = Faker.Name.FullName();
            result.CreateAt = new DateTime();
            result.UpdateAt = new DateTime();
            result.Email = userLogin.Email;

            Response response = new Response(201, result);

            //Act - Buscar por usuários com as informações passadas.
            mock = new Mock<IAuthService>();
            mock.Setup(m => m.DoLoginAsync(userLogin)).ReturnsAsync(response);
            authService = mock.Object;

            //Assert

            var result_service = await authService.DoLoginAsync(userLogin);

            Assert.NotNull(result_service);
            Assert.Equal(result_service.Data.Email, userLogin.Email);
        }
    }
}
