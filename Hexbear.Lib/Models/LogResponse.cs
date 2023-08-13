using Hexbear.Lib.EFCore;

namespace Hexbear.Lib.Models
{
    public class LogResponse
    {
        public List<DockerLog> Logs { get; set; }
    }
}