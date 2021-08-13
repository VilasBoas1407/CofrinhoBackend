using Domain.Entities.Planejamento;
using Domain.Enums;
using System;

namespace Domain.Entities.Expenses
{
    public class DespesasEntity : BaseEntity
    {
   
        public RecorrenciaEnum Recorrencia { get; set; }
        public double ValorParcela { get; set; }
        public double ValorTotal { get; set; }
        public int QuantidadeParcelas { get; set; }
        public int ParcelaAtual { get; set; }
        public bool GastoFixo { get; set; }
        public bool Quitado { get; set; }

        public Guid IdUsuario { get; set; }
        public UserEntity User { get; set; }

        public Guid IdPlanejamento { get; set; }
        public PlanejamentoEntity Planejamento { get; set; }

        public Guid IdTipoDespesa { get; set; }
        public TipoDespesaEntity TipoDespesa { get; set; }

    }
}
