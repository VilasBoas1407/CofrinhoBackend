using Service.Utils;
using System;
using Xunit;

namespace Testes.Utils
{
    public class DataUtilsTest
    {
        /// <summary>
        /// É esperado que ele atualize o ano e o mês 
        /// </summary>
        [Fact]
        public void DeveRealizarAConversaoDoMeses()
        {
            //Arrange
            int MesReferencia = 16;
            int AnoReferencia = 2021;

            //Act
            DataUtils.ConverterNumeroDeMesesParaData(ref MesReferencia, ref AnoReferencia);

            //Assert
            Assert.Equal(2022, AnoReferencia);
            Assert.Equal(4, MesReferencia);
        }


        [Fact]
        public void DeveRealizarAConversaoDoMesesQuandoONumeroDeMesEhInferiorAh12()
        {
            //Arrange
            int MesReferencia = 11;
            int AnoReferencia = 2021;
            //Act
            DataUtils.ConverterNumeroDeMesesParaData(ref MesReferencia, ref AnoReferencia);

            //Assert
            Assert.Equal(2021, AnoReferencia);
            Assert.Equal(11, MesReferencia);
        }

        [Fact]
        public void DeveRealizarAConversaoQuandoOsMesesInteram1Ano()
        {
            //Arrange
            int MesReferencia = 24;
            int AnoReferencia = 2021;

            //Act
            DataUtils.ConverterNumeroDeMesesParaData(ref MesReferencia, ref AnoReferencia);

            //Assert
            Assert.Equal(2023, AnoReferencia);
            Assert.Equal(12, MesReferencia);
        }
    }
}
