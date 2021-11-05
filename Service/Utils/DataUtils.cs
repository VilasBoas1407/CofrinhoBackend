using Domain.Entities.Planejamento;
using Domain.Enums;

namespace Service.Utils
{
    /// <summary>
    /// Classe para formatar datas
    /// </summary>
    public static class DataUtils
    {
        public static void ConverterNumeroDeMesesParaData(ref int mesReferencia, ref int anoReferencia)
        {
            bool ehDezembro = false;

            int Anos = mesReferencia / 12;
            int MesesRestantes = mesReferencia % 12;

            //Caso seja igual a 0, significa que o mês é múltiplo de 12
            if (MesesRestantes == 0)
            {
                MesesRestantes = 12;
                ehDezembro = true;
            }

            mesReferencia = MesesRestantes;

            if (Anos == 0 && MesesRestantes == 1)
                anoReferencia += 1;

            if (Anos >= 1)
                anoReferencia += Anos;
            else if(ehDezembro)
                anoReferencia += Anos;

        }

    }
}
