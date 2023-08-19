using Microsoft.Extensions.Configuration;

namespace Hexbear.Lib
{
    public class Appsettings
    {
        public string ConnectionString { get; set; } 
        public Appsettings(IConfiguration config) {
            this.ConnectionString = config.GetValue<string>("ConnectionString");
        }
    }
}
