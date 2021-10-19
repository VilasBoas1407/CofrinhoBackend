using Domain.Entities.Expenses;
using System;

namespace Domain.Entities.Planejamento
{
    public class PlanejamentoDespesasEntity : BaseEntity
    {
        public Guid IdUsuario { get; set; }
        public Guid IdDespesa { get; set; }
        public Guid IdPlanejamento { get; set; }
    }
}
