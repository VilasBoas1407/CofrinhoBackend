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
using Microsoft.IdentityModel.Tokens;
using Service.Utils;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
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


        public Response DoLogin(LoginRequestDTO loginRequest)
        {
            try
            {

                loginRequest.Password = new Hash().CriptografarSenha(loginRequest.Password);

                UserEntity user = userRepository
                                .SelectWithFilter(u => u.Email.Equals(loginRequest.Email) && u.Password.Equals(loginRequest.Password))
                                .FirstOrDefault();

                if (user != null)
                {
                    LoginHistoryEntity history = new LoginHistoryEntity();

                    history.Name = user.Name;
                    history.Email = user.Email;
                    history.CreateAt = DateTime.Now;

                    loginHistoryRepository.Insert(history);

                    LoginResponseDTO responseDTO = mapper.Map<LoginResponseDTO>(user);

                    ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Email),
                        new[]
                        {
                                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
                        }
                    );


                    DateTime createDate = DateTime.Now;
                    DateTime experationDate = createDate + TimeSpan.FromSeconds(tokenConfigurations.Seconds);


                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, experationDate, handler);

                    responseDTO.planejamentoAtivo = planejamentoService.GetPlanejamentoAtivoByUser(user.Id);

                    responseDTO.Token = token;
                    responseDTO.TokenExpiration = experationDate;

                    var result = responseDTO;

                    return new Response(200, result);
                }
                else
                {
                    return new Response(401, "Usuário ou senha inválidos!");
                }
            }
            catch (Exception ex)
            {
                return new Response(500, "Ocorreu um erro ao realizar a autenticação:" + ex.Message);
            }
        }

        public Response DoRegister(UserRegisterRequestDTO userRegister)
        {
            try
            {
                UserEntity user = mapper.Map<UserEntity>(userRegister);

                bool hasEmailCadastrado = userRepository.Exist(u => u.Email.Equals(user.Email));

                if (hasEmailCadastrado)
                    return new Response(400, "E-mail já cadastrado na base de dados!");

                user.Password = new Hash().CriptografarSenha(userRegister.Password);

                var result = userRepository.Insert(user);

                PlanejamentoRegisterDTO planejamentoRegister = new PlanejamentoRegisterDTO();

                planejamentoRegister.MesReferencia = DateTime.Now.Month;
                planejamentoRegister.AnoReferencia = DateTime.Now.Year;
                planejamentoRegister.IdUsuario = result.Id;


                var resultPlanejamento = planejamentoService.DoRegister(planejamentoRegister);

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

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime experationDate, JwtSecurityTokenHandler handler)
        {
            try
            {
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = createDate,
                    Expires = experationDate
                });

                var token = handler.WriteToken(securityToken);
                return token;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
