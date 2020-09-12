using Brka.Bank.Lib.WebApi;
using Microsoft.Extensions.Configuration;

namespace Brka.Bank.BacenGateway.WebApi
{
    public class Startup : StartupBase 
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }
    }
}