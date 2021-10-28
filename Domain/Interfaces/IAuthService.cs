using Domain.DTO;
using Domain.DTO.Login;
using Domain.Utils;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAuthService 
    {
        Response DoLogin(LoginRequestDTO login);
        Response DoRegister(UserRegisterRequestDTO userRegister);
    }
}
