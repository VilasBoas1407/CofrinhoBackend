using Domain.Entities.Expenses;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Planejamento
{
    public class PlanejamentoEntity : BaseEntity
    {

        public MesesEnum MesReferencia { get; set; }
        public int AnoReferencia { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Ativo { get; set; }

        public Guid IdUsuario { get; set; }
        public UserEntity User { get; set; }
        public List<DespesasEntity> Despesas { get; set; }

    }
}
