using Hexbear.Lib.Models;
using System.Text.Json;

namespace Hexbear.API.Services
{
    public class LogService
    {
        public async Task<LogResponse> ListLogs()
        {
            //Get logs from volume within container
            var directory = $@"{Directory.GetCurrentDirectory()}/Logs/";
#if DEBUG
            directory = $@"{Directory.GetCurrentDirectory()}\bin\Debug\net7.0\Logs\";
#endif
            var logs = new List<DockerLog>();
            var containers = Directory.EnumerateDirectories(directory);
            var whitelistedHostNames = new List<string>()
            {
                "dashboard-api",
                "lemmy",
                "lemmy-ui",
                "pictrs",
            };
            foreach (var container in containers)
            {
                if (!File.Exists($@"{container}/hostname"))
                    continue;
                string hostname = (await File.ReadAllTextAsync($@"{container}/hostname")).Trim();
                if (!whitelistedHostNames.Contains(hostname))
                    continue;
                var files = Directory.EnumerateFiles($@"{container}/", "*json.log*", SearchOption.AllDirectories).ToList();
                var logItems = files.SelectMany(y =>
                {
                    var logs = File.ReadAllLines(y).Select(x => JsonSerializer.Deserialize<DockerLog>(x)).ToList();
                    var filename = new FileInfo(y).Name;
                    foreach (var log in logs)
                        log.container = hostname;
                    return logs;
                }).OrderByDescending(x => x.time).Take(300).ToList();
                logs.AddRange(logItems);
            }

            return new LogResponse()
            {
                Logs = logs
            };
        }
    }
}
