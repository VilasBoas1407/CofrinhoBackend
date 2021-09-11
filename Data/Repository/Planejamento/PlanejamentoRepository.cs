using Data.Context;
using Domain.Entities.Planejamento;
using Domain.Repository.Planejamento;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.Planejamento
{

    public class PlanejamentoRepository : BaseRepository<PlanejamentoEntity>, IPlanejamentoRepository
    {
        private DbSet<PlanejamentoEntity> _dataset;

        public PlanejamentoRepository(CofrinhoContext context) : base(context)
        {
            _dataset = context.Set<PlanejamentoEntity>();
        }


        public PlanejamentoEntity GetPlanejamentoAtivoByUser(Guid idUser)
        {
            try
            {
                PlanejamentoEntity data = _dataset
                    .Where(p => p.Ativo == true && p.IdUsuario.Equals(idUser)).FirstOrDefault();

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
