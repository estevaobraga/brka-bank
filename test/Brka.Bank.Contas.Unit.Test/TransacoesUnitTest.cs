using Xunit;
using Bogus;
using Brka.Bank.Contas.Domain;
using FluentAssertions;

namespace Brka.Bank.Contas.Unit.Test
{
    public class TransacoesUnitTest
    {
        [Fact]
        public void Quando_Possuir_Uma_Transacao_De_Credito_Entao_Deve_Acrescestar_Saldo_Conta()
        {
            // Arrange
            var transacao = new Faker<Transacao>().Rules((faker, tran) =>
            {
                tran.Id = faker.IndexFaker;
                tran.Valor = faker.Random.Decimal(1, 100);
                tran.IdConta = faker.IndexFaker;
                tran.IdUsuario = faker.IndexFaker;
                tran.TipoTransacao = TipoTransacao.Credito;
                tran.SaldoEmConta = 0;
            }).Generate();
            var valorPosteriorEsperado = transacao.SaldoEmConta + transacao.Valor;

            // Act & Assert
            transacao.ValorPosterior.Should().BeGreaterThan(0);
            transacao.ValorPosterior.Should().Be(valorPosteriorEsperado);
        }

        [Fact]
        public void Quando_Possuir_Uma_Transacao_De_Debito_Entao_Deve_Subtrair_Saldo_Conta()
        {
            // Arrange
            var transacao = new Faker<Transacao>().Rules((faker, tran) =>
            {
                tran.Valor = faker.Random.Decimal(1, 100);
                tran.TipoTransacao = TipoTransacao.Credito;
                tran.TipoTransacao = TipoTransacao.Debito;
                tran.SaldoEmConta = 100;
            }).Generate();
            var valorPosteriorEsperado = transacao.SaldoEmConta - transacao.Valor;
            
            // Act & Assert
            transacao.ValorPosterior.Should().BeLessThan(100);
            transacao.ValorPosterior.Should().Be(valorPosteriorEsperado);
        }

        [Fact]
        public void Quando_Adiciona_Conta_Corrente_E_Chamado_Deve_Preencher_Valores_Corretamente()
        {
            // Arrage
            var contaCorrente = new Faker<ContaCorrente>().Rules((faker, conta) =>
            {
                conta.Id = faker.IndexFaker;
                conta.IdUsuario = faker.IndexFaker;
                conta.Saldo = faker.Random.Decimal(1, 100);
            }).Generate();
            
            var transacaoConta = new Faker<Transacao>().Rules((faker, transacao) =>
            {
                transacao.Id = faker.IndexFaker;
            }).Generate();

            // Act
            transacaoConta = transacaoConta.AdicionaContaCorrente(contaCorrente);
            
            // Assert
            transacaoConta.Id.Should().Be(0);
            transacaoConta.IdConta.Should().Be(contaCorrente.Id);
            transacaoConta.IdUsuario.Should().Be(contaCorrente.IdUsuario);
            transacaoConta.SaldoEmConta.Should().Be(contaCorrente.Saldo);
        }

        [Fact]
        public void Quando_Adiciona_Operacao_Transacao_E_Chamado_Deve_Preencher_Valores_Corretamente()
        {
            // Arrage
            var valorTrasacao = new Faker().Random.Decimal(1, 10);
            var transacao = new Faker<Transacao>().Rules((faker, entity) =>
            {
                entity.Id = faker.IndexFaker;
            }).Generate();

            // Act
            transacao = transacao.AdicinaOperacaoTrasacao(TipoTransacao.Credito, valorTrasacao);
            
            // Assert
            transacao.TipoTransacao.Should().Be(TipoTransacao.Credito);
            transacao.Valor.Should().Be(valorTrasacao);
            transacao.DataTrasacao.Should().NotBe(default);
        }
    }
}