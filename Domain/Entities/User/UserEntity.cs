using Domain.Entities.Expenses;
using Domain.Entities.Planejamento;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        #region Relacionamentos

        public List<PlanejamentoEntity> Planejamentos { get; set; }
        public List<TipoDespesaEntity> TipoDespesas { get; set; }
        public List<DespesasEntity> Despesas { get; set; }

        #endregion
    }
}
