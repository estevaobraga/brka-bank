namespace Brka.Bank.BacenGateway.WebApi.Domain
{
    public class TaxaDeJuros
    {
        private int DiasUteis => 253;
        public decimal SelicOver => (decimal) 1.9;
        public decimal Selic => 2;
        public decimal Cdi => SelicOver;
        public decimal CdiDia => Cdi / DiasUteis;
    }
}