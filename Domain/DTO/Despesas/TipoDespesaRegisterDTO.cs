using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTO.Despesas
{
    public class TipoDespesaRegisterDTO
    {
        [Required(ErrorMessage ="Nome é um campo obrigatório")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        /// <summary>
        /// Caso seja false é porque é uma receita
        /// </summary>
        [Required(ErrorMessage = "IsDespesa é um campo obrigatório para registro!")]
        public bool IsDespesa { get; set; }

        [Required(ErrorMessage = "IdUsuario é um campo obrigatório para registro!")]
        public Guid IdUsuario { get; set; }
    }
}
