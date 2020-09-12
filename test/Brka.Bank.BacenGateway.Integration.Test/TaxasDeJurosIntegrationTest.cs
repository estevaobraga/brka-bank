using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Brka.Bank.BacenGateway.Integration.Test
{
    public class TaxasDeJurosIntegrationTest : StartServerBacenGateway
    {
        [Fact]
        public async Task Quando_Consulta_Taxa_Selic_Deve_Retornar_Com_Sucesso()
        {
            // Act
            var httpResponse = await Client.GetAsync("TaxasDeJuros/Selic");
            
            // Assert
            httpResponse.Content.ReadAsStringAsync().Result.Should().Be("2");
            httpResponse.EnsureSuccessStatusCode();
        }
        
        [Fact]
        public async Task Quando_Consulta_Taxa_Cdi_Dia_Deve_Retornar_Com_Sucesso()
        {
            // Act
            var httpResponse = await Client.GetAsync("TaxasDeJuros/Selic");
            
            // Assert
            httpResponse.EnsureSuccessStatusCode();
        }
 
        [Fact]
        public async Task Quando_Consulta_Taxa_Cdi_Deve_Retornar_Com_Sucesso()
        {
            // Act
            var httpResponse = await Client.GetAsync("TaxasDeJuros/Cdi");
            
            // Assert
            httpResponse.EnsureSuccessStatusCode();
        }
        
        [Fact]
        public async Task Quando_Consulta_Taxa_CdiDia_Deve_Retornar_Com_Sucesso()
        {
            // Act
            var httpResponse = await Client.GetAsync("TaxasDeJuros/CdiDia");
            
            // Assert
            httpResponse.EnsureSuccessStatusCode();
        }
    }
}