using System.ComponentModel.DataAnnotations;

namespace Domain.DTO.Login
{
    public class UserRegisterRequestDTO
    {
        
        [Required(ErrorMessage = "Name é um campo obrigatório para registro!")]
        [StringLength(50, ErrorMessage = "Name dever ter no máximo {1} caracteres!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é um campo obrigatório para registro!")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        [StringLength(100, ErrorMessage = "Email dever ter no máximo {1} caracteres!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password é um campo obrigatório para o registro!")]
        [StringLength(16, ErrorMessage = "Password dever ter no máximo {1} caracteres!")]
        public string Password { get; set; }
    }
}
