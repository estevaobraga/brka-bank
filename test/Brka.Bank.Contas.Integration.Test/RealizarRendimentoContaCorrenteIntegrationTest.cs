using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Brka.Bank.Contas.Integration.Test
{
    public class RealizarRendimentoContaCorrenteIntegrationTest : StartServerTest
    {
        [Fact]
        public async Task Quando_Rentabilizacao_Conta_Corrente_E_Chamado_Entao_Deve_Processar_Corretamente()
        {
            // Act
            var response = await Client.PutAsync("RealizarRendimentoContaCorrente", new MultipartContent());

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}