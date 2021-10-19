using Domain.Entities.Expenses;
using System;

namespace Domain.Entities.Planejamento
{
    public class PlanejamentoDespesaEntity : BaseEntity
    {
        public Guid IdUsuario { get; set; }
        public Guid IdDespesa { get; set; }
        public Guid IdPlanejamento { get; set; }


        public DespesasEntity Despesas { get; set;}
        public UserEntity User { get; set; }
        public PlanejamentoEntity Planejamento { get; set; }
    }
}
