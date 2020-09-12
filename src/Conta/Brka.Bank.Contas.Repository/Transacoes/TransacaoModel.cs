using System;

namespace Brka.Bank.Contas.Repository.Transacoes
{
    public class TransacaoModel
    {
        public int Id { get; set; }
        public int IdConta { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataTrasacao { get; set; }
        public decimal SaldoEmConta { get; set; }
        public decimal Valor { get; set; }
        public int TipoTransacao { get; set; }
    }
}