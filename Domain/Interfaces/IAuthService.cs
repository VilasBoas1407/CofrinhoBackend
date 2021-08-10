using Domain.DTO;
using Domain.DTO.Login;
using Domain.Utils;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAuthService 
    {
        Task<Response> DoLoginAsync(LoginRequestDTO login);
        Task<Response> DoRegisterAsync(UserRegisterRequestDTO userRegister);
    }
}
