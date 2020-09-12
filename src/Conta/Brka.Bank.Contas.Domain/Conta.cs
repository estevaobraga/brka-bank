namespace Brka.Bank.Contas.Domain
{
    public abstract class Conta
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int Tipo { get; set; }
        public int CodigoAgencia { get; set; }
        public int Numero { get; set; }
        public int Digito { get; set; }
        public decimal Saldo { get; set; }

        public abstract void CreditoEmConta(decimal valor);
        public abstract void DebitoEmConta(decimal valor);
    }
}