using Brka.Bank.Contas.WebApi;
using FluentAssertions;
using Xunit;

namespace Brka.Bank.Contas.Unit.Test
{
    public class RentabilizaCdiTest
    {
        [Fact]
        public void Valida_Inicializacao_Servico_Rentabilizacao_Conta_Corrente()
        {
            // Arrange
            var scheduler = RentabilizaCdi.ObtemSchedulerStart();

            // Act
            RentabilizaCdi.Start();

            // Assert
            scheduler.IsStarted.Should().Be(true);
            scheduler.Shutdown().Wait();
            scheduler.IsShutdown.Should().Be(true);
        }
    }
}