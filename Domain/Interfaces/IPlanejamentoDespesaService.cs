using Domain.DTO.Planejamento;
using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPlanejamentoDespesaService
    {
        Task<Response> DoRegisterAsync(PlanejamentoDespesaDTO register);
    }
}
