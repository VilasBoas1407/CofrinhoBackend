using Data.Context;
using Domain.DTO;
using Domain.DTO.Login;
using Domain.Interfaces;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;
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

        const string usuarioCadastradoComSucesso = "Usuário cadastrado com sucesso!";
        const string usuarioJaCadastrado = "E-mail já cadastrado na base de dados!";
        
        
        // Refazer esses testes, utilizando o DbContext, para poder validar direito

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
            mock.Setup(m => m.DoLogin(userLogin)).Returns(response);
            authService = mock.Object;

            //Assert

            var result_service = authService.DoLogin(userLogin);

            Assert.NotNull(result_service);
            Assert.Equal(result_service.Result.Email, userLogin.Email);
        }

        [Fact]
        public void DeveRealizarOCadastradoDoUsuario()
        {
            //Arrange
            string Email = Faker.Internet.Email();
            string Name = Faker.Name.FullName();
            string Password = new Hash().CriptografarSenha("123456");


            var userRegister = new UserRegisterRequestDTO()
            {
                Email = Email,
                Name = Faker.Name.FullName(),
                Password = "123456"
            };

            Response response = new Response(201, usuarioCadastradoComSucesso);


            //Act - Buscar por usuários com as informações passadas.
            mock = new Mock<IAuthService>();
            mock.Setup(m => m.DoRegister(userRegister)).Returns(response);
            authService = mock.Object;

            //Assert
            Assert.Equal(201,response.StatusCode);
            Assert.Equal(usuarioCadastradoComSucesso, response.Message);
        }

        [Fact]
        public void DeveValidarSeOEmailJaEstaCadastradoNaBase()
        {
            //Arrange
            string Email = Faker.Internet.Email();
            string Name = Faker.Name.FullName();
            string Password = new Hash().CriptografarSenha("123456");

            var userRegister = new UserRegisterRequestDTO()
            {
                Email = Email,
                Name = Faker.Name.FullName(),
                Password = "123456"
            };

            Response response = new Response(400, usuarioJaCadastrado);

            var options = new DbContextOptionsBuilder<CofrinhoContext>().UseInMemoryDatabase("CofrinhoContext").Options;
            var contexto = new CofrinhoContext(options);

            //Act - Buscar por usuários com as informações passadas.
            mock = new Mock<IAuthService>();
            mock.Setup(m => m.DoRegister(userRegister));
            authService = mock.Object;
            var resultPrimeiroCadastro = authService.DoRegister(userRegister);

            mock = new Mock<IAuthService>();
            mock.Setup(m => m.DoRegister(userRegister));
            authService = mock.Object;

            var resultSegundoCadastro = authService.DoRegister(userRegister);

            //Assert
            Assert.Equal(400, response.StatusCode);
            Assert.Equal(usuarioJaCadastrado, response.Message);
        }

    }
}
