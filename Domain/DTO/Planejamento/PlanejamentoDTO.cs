using Domain.Enums;
using System;

namespace Domain.DTO.Planejamento
{
    public class PlanejamentoDTO
    {
        public MesesEnum MesReferencia { get; set; }
        public int AnoReferencia { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Ativo { get; set; }
    }
}
