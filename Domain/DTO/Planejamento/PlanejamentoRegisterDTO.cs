using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTO.Planejamento
{
    public class PlanejamentoRegisterDTO
    {
        [Required(ErrorMessage = "MesReferencia é um campo obrigatório para registro!")]
        public int MesReferencia { get; set; }

        [Required(ErrorMessage = "AnoReferencia é um campo obrigatório para registro!")]
        public int AnoReferencia { get; set; }

        public bool Ativo { get; set; }

        [Required(ErrorMessage = "IdUsuario é um campo obrigatório para registro!")]
        public Guid IdUsuario { get; set; }

        public bool AtualizarPlanejamentoAtivo { get; set; }

    }
}
