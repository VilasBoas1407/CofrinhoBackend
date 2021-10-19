using Domain.Enums;
using System;

namespace Domain.DTO.Despesas
{
    public class DespesaRegisterDTO
    {
        public Guid Id { get; set; }
        public RecorrenciaEnum Recorrencia { get; set; }
        public double ValorParcela { get; set; }
        public int QuantidadeParcelas { get; set; }
        public int ParcelaAtual { get; set; }
        public bool GastoFixo { get; set; }
        public bool Quitado { get; set; }
        public bool AlterarSomenteUm { get; set; }
        public Guid IdUsuario { get; set;}
        public Guid IdTipoDespesa { get; set; }
    }
}
