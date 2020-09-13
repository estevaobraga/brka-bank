using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Brka.Bank.Contas.Domain;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Brka.Bank.Contas.Integration.Test
{
    public class ContaCorrenteIntegrationTest : StartServerTest
    {
        [Fact]
        public async Task Quando_Consulta_Extrato_Deve_Retornar_Com_Sucesso()
        {
            // Act
            var response = await Client.GetAsync("ExtratoContaCorrente");

            // Assert
            response.EnsureSuccessStatusCode();
            var extrato = JsonConvert.DeserializeObject<List<Transacao>>(response.Content.ReadAsStringAsync().Result);
            extrato.Should().NotBeNullOrEmpty();
        }
        
        [Fact]
        public async Task Quando_Consulta_Conta_Corrente_Deve_Retornar_Com_Sucesso()
        {
            // Act
            var response = await Client.GetAsync("ContaCorrente/4763/11458621/1");

            // Assert
            response.EnsureSuccessStatusCode();
            var conta = JsonConvert.DeserializeObject<ContaCorrente>(response.Content.ReadAsStringAsync().Result);
            conta.Id.Should().Be(1);
            conta.CodigoAgencia.Should().Be(4763);
            conta.Numero.Should().Be(11458621);
            conta.Digito.Should().Be(1);
        }
        
        [Fact]
        public async Task Quando_Depositar_Valor_Deve_Retornar_Sucesso()
        {
            // Act
            var httpContent = new MultipartFormDataContent
            {
                {new StringContent("4763"), "codigoAgencia"},
                {new StringContent("11458621"), "numero"},
                {new StringContent("1"), "digito"},
                {new StringContent("1"), "valor"}
            };
            var response = await Client.PutAsync("ContaCorrente/Deposito", httpContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }
        
        [Fact]
        public async Task Quando_Resgatar_Valor_Deve_Retornar_Obter_Sucesso()
        {
            // Act
            var httpContent = new MultipartFormDataContent
            {
                {new StringContent("4763"), "codigoAgencia"},
                {new StringContent("11458621"), "numero"},
                {new StringContent("1"), "digito"},
                {new StringContent("1"), "valor"}
            };
            var response = await Client.PutAsync("ContaCorrente/Resgate", httpContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }
        
        [Fact]
        public async Task Quando_E_Realizado_Pagamento_De_Boleto_Valido_Deve_Obter_Sucesso()
        {
            // Act
            var httpContent = new MultipartFormDataContent
            {
                {new StringContent("4763"), "codigoAgencia"},
                {new StringContent("11458621"), "numero"},
                {new StringContent("1"), "digito"},
                {new StringContent("1"), "valor"},
                {new StringContent("1"), "boleto"}
            };
            var response = await Client.PutAsync("ContaCorrente/PagarBoleto", httpContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}