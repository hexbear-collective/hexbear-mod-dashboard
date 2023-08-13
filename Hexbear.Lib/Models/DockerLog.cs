
namespace Hexbear.Lib.Models
{
    public class DockerLog
    {
        public string log { get; set; }
        public string stream { get; set; }
        public DateTime time { get; set; }
        public string container { get; set; }
    }
}
