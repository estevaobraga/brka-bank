using System;

namespace Brka.Bank.Contas.Domain
{
    public class Transacao
    {
        public int Id { get; set; }
        public int IdConta { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataTrasacao { get; set; }
        public decimal SaldoEmConta { get; set; }
        public decimal Valor { get; set; }

        public decimal ValorPosterior =>
            TipoTransacao == TipoTransacao.Credito ? SaldoEmConta + Valor : SaldoEmConta - Valor;

        public TipoTransacao TipoTransacao { get; set; }

        public Transacao AdicionaContaCorrente(Conta conta)
        {
            IdConta = conta.Id;
            IdUsuario = conta.IdUsuario;
            SaldoEmConta = conta.Saldo;

            return this;
        }

        public Transacao AdicinaOperacaoTrasacao(TipoTransacao tipoTransacao, decimal valorTransacao)
        {
            TipoTransacao = tipoTransacao;
            Valor = valorTransacao;
            DataTrasacao = DateTime.Now;

            return this;
        }
    }
}