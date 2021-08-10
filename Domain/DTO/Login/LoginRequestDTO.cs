using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class LoginRequestDTO
    {

        [Required(ErrorMessage = "Email é um campo obrigatório para Login!")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        [StringLength(100, ErrorMessage = "Email dever ter no máximo {1} caracteres!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password é um campo obrigatório para Login!")]
        public string Password { get; set; }
    }
}
