using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO.Login
{
    public class LoginResponseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Token {get;set;}
        public DateTime TokenExpiration { get; set; }

    }
}
