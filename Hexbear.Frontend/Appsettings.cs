using Microsoft.Extensions.Configuration;

namespace Hexbear.Lib
{
    public class Appsettings
    {
        public string APIUrl { get; set; } 
        public Appsettings(IConfiguration config) {
            this.APIUrl = config.GetValue<string>("APIUrl");
        }
    }
}
