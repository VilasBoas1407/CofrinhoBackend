using System;

namespace Domain.DTO.Planejamento
{
    public class PlanejamentoDespesaDTO
    {
        public Guid IdUsuario { get; set; }
        public Guid IdDespesa { get; set; }
        public Guid IdPlanejamento { get; set; }
    }
}
