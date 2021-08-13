using Domain.Entities.Expenses;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Planejamento
{
    public class TipoDespesaEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool IsDespesa { get; set; }

        public Guid IdUsuario { get; set; }
        public UserEntity User { get; set; }
        public List<DespesasEntity> Despesas { get; set; }
    }
}
