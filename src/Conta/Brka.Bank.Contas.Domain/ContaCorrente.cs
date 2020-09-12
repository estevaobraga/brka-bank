using System;
using Brka.Bank.Lib.WebApi;

namespace Brka.Bank.Contas.Domain
{
    public class ContaCorrente : Conta
    {
        public override void CreditoEmConta(decimal valor)
        {
            if (ValorMenorIgualAZero(valor))
                throw new BusinessException("O valor de credito não pode ser menor ou igual a zero");
            Saldo += valor;
        }

        public override void DebitoEmConta(decimal valor)
        {
            if (ValorMenorIgualAZero(valor))
                throw new BusinessException("O valor de Debito não pode ser menor ou igual a zero");
            if(Saldo < valor)
                throw new BusinessException("A Conta não possui saldo suficiente para realizar transação");
            Saldo -= valor;
        }

        public void PagamentoBoleto(string boleto, decimal valor)
        {
            if (String.IsNullOrEmpty(boleto))
                throw new BusinessException("Boleto não informado");
            DebitoEmConta(valor);
        }
        
        private bool ValorMenorIgualAZero(decimal valor) => valor <= 0;
    }
}