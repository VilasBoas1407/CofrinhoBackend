using AutoMapper;
using Domain.DTO;
using Domain.DTO.Login;
using Domain.DTO.Planejamento;
using Domain.Entities;
using Domain.Entities.History;
using Domain.Interfaces;
using Domain.Repository;
using Domain.Repository.History;
using Domain.Security;
using Domain.Utils;
using Microsoft.Extensions.Configuration;
using Service.Utils;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Service.Auth
{
    public class AuthService : IAuthService
    {
        private IUserRepository userRepository;
        private ILoginHistoryRepository loginHistoryRepository;
        public SigningConfigurations signingConfigurations;
        public TokenConfigurations tokenConfigurations;
        private IConfiguration configuration { get; }
        private readonly IMapper mapper;
        private IPlanejamentoService planejamentoService;

        public AuthService(IUserRepository _userRepository, 
                    SigningConfigurations _signingConfigurations,
                    TokenConfigurations _tokenConfigurations,
                    IConfiguration _configuration,
                    IMapper _mapper,
                    ILoginHistoryRepository _loginHistoryRepository,
                    IPlanejamentoService _planejamentoService)
        {
            userRepository = _userRepository;
            signingConfigurations = _signingConfigurations;
            tokenConfigurations = _tokenConfigurations;
            configuration = _configuration;
            mapper = _mapper;
            loginHistoryRepository = _loginHistoryRepository;
            planejamentoService = _planejamentoService;
        }


        public async Task<Response> DoLoginAsync(LoginRequestDTO loginRequest)
        {
            try
            {

                loginRequest.Password = new Hash().CriptografarSenha(loginRequest.Password);

                UserEntity user = userRepository
                                .SelectWithFilter(u => u.Email.Equals(loginRequest.Email) && u.Password.Equals(loginRequest.Password))
                                .FirstOrDefault();

                if(user != null)
                {
                    LoginHistoryEntity history = new LoginHistoryEntity();

                    history.Name = user.Name;
                    history.Email = user.Email;

                    await loginHistoryRepository.InsertAsync(history);

                    var result = mapper.Map<LoginResponseDTO>(user);
                    return new Response(200, result);
                }
                else
                {
                    return new Response(401, "Usuário ou senha inválidos!");
                }
            }
            catch (Exception ex)
            {
                return new Response(500,  "Ocorreu um erro ao realizar a autenticação:" + ex.Message);
            }
        }

        public async Task<Response> DoRegisterAsync(UserRegisterRequestDTO userRegister)
        {
            try
            {
                UserEntity user = mapper.Map<UserEntity>(userRegister);

                bool hasEmailCadastrado =  userRepository.ExistAsync(u => u.Email.Equals(user.Email));

                if (hasEmailCadastrado)
                    return new Response(400, "E-mail já cadastrado na base de dados!");

                user.Password = new Hash().CriptografarSenha(userRegister.Password);

                var result = await userRepository.InsertAsync(user);

                PlanejamentoRegisterDTO planejamentoRegister = new PlanejamentoRegisterDTO();

                planejamentoRegister.MesReferencia = DateTime.Now.Month;
                planejamentoRegister.AnoReferencia = DateTime.Now.Year;
                planejamentoRegister.DataInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                planejamentoRegister.DataFim = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                planejamentoRegister.IdUsuario = result.Id;
                planejamentoRegister.Ativo = true;

                var resultPlanejamento = await planejamentoService.DoRegisterAsync(planejamentoRegister);

                if (result != null)
                    return new Response(201, "Usuário cadastrado com sucesso!");
                else
                    return new Response(400, "Erro ao cadastrar usuário!");
            }
            catch (Exception ex)
            {
                return new Response(500, "Ocorreu um erro ao realizar o cadastro:" + ex.Message);
            }
        }
    }
}
