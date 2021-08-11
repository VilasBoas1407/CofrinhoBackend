using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO.Login
{
    public class LoginResponseDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
