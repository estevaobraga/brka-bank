using Bogus;
using Brka.Bank.Contas.Domain;
using Brka.Bank.Lib.WebApi;
using FluentAssertions;
using Xunit;

namespace Brka.Bank.Contas.Unit.Test
{
    public class ContaCorrenteUnitTest
    {
        [Fact]
        public void Quando_E_Realizado_Um_Debito_Em_Conta_Deve_Subtrair_Saldo()
        {
            // Arrange
            var contaCorrente = new Faker<ContaCorrente>("pt_BR").Rules((faker, conta) =>
            {
                conta.Id = faker.IndexFaker;
                conta.Digito = 1;
                conta.Numero = faker.Random.Int(00000000, 99999999);
                conta.Saldo = faker.Random.Decimal(10, 100);
                conta.Tipo = 1;
                conta.CodigoAgencia = faker.Random.Int(0000, 9999);
                conta.IdUsuario = faker.IndexFaker;
            }).Generate();
            decimal valorDebito = 10;
            var valorAnterior = contaCorrente.Saldo;
            
            // Act
            contaCorrente.DebitoEmConta(valorDebito);
            
            // Assert
            contaCorrente.Saldo.Should().BeLessThan(valorAnterior);
            contaCorrente.Saldo.Should().Be(valorAnterior - valorDebito);
        }
        
        [Fact]
        public void Quando_E_Realizado_Um_Credito_Em_Conta_Deve_Somar_Saldo()
        {
            // Arrange
            var contaCorrente = new Faker<ContaCorrente>("pt_BR").Rules((faker, conta) =>
            {
                conta.Saldo = faker.Random.Decimal(10, 100);
            }).Generate();
            decimal valorCredito = 10;
            var valorAnterior = contaCorrente.Saldo;
            
            // Act
            contaCorrente.CreditoEmConta(valorCredito);
            
            // Assert
            contaCorrente.Saldo.Should().BeGreaterThan(valorAnterior);
            contaCorrente.Saldo.Should().Be(valorAnterior + valorCredito);
        }
        
        [Fact]
        public void Quando_E_Realizado_Um_Pagamento_De_Boleto_Entao_Conta_Deve_Subtrair_Saldo()
        {
            // Arrange
            var contaCorrente = new Faker<ContaCorrente>("pt_BR").Rules((faker, conta) =>
            {
                conta.Saldo = faker.Random.Decimal(10, 100);
            }).Generate();
            decimal valorCredito = 10;
            var valorAnterior = contaCorrente.Saldo;
            
            // Act
            contaCorrente.PagamentoBoleto("32154", valorCredito);
            
            // Assert
            contaCorrente.Saldo.Should().BeLessThan(valorAnterior);
            contaCorrente.Saldo.Should().Be(valorAnterior - valorCredito);
        }

        [Fact]
        public void Quando_Tentar_Realizar_Debito_Em_Conta_Com_Valor_Negativo_Deve_Obter_BusinessExption()
        {
            // Arrange
            var valorDebito = (decimal) -10;
            var conta = new ContaCorrente();
            
            // Act & Assert
            Assert.Throws<BusinessException>(() => conta.DebitoEmConta(valorDebito));
        }
        
        [Fact]
        public void Quando_Tentar_Realizar_Credito_Em_Conta_Com_Valor_Negativo_Deve_Obter_BusinessExption()
        {
            // Arrange
            var valorDebito = (decimal) -10;
            var conta = new ContaCorrente();
            
            // Act & Assert
            Assert.Throws<BusinessException>(() => conta.CreditoEmConta(valorDebito));
        }
        
        [Fact]
        public void Quando_Tentar_Realizar_Pagamento_De_Valor_Negativo_Deve_Obter_BusinessExption()
        {
            // Arrange
            var valorDebito = (decimal) -10;
            var conta = new ContaCorrente();
            
            // Act & Assert
            Assert.Throws<BusinessException>(() => conta.PagamentoBoleto("boleto", valorDebito));
        }
        
        [Fact]
        public void Quando_Tentar_Realizar_Pagamento_Sem_Informar_Boleto_Deve_Obter_BusinessExption()
        {
            // Arrange
            var valorDebito = (decimal) 10;
            var conta = new ContaCorrente();
            
            // Act & Assert
            Assert.Throws<BusinessException>(() => conta.PagamentoBoleto("", valorDebito));
        }
        
        [Fact]
        public void Quando_Tentar_Realizar_Debito_Maior_Que_Saldo_Em_Conta_Deve_Obter_BusinessExption()
        {
            // Arrange
            var valorDebito = (decimal) 10;
            var contaCorrente = new Faker<ContaCorrente>("pt_BR").Rules((faker, conta) =>
            {
                conta.Saldo = 0;
            }).Generate();
            
            // Act & Assert
            Assert.Throws<BusinessException>(() => contaCorrente.DebitoEmConta(valorDebito));
        }
    }
}