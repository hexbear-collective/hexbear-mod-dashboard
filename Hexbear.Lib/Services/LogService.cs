﻿using Hexbear.Lib.Models;
using System.Text.Json;

namespace Hexbear.Lib.Services
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
            };
            foreach (var container in containers)
            {
                if (!File.Exists($@"{container}/hostname"))
                    continue;
                string hostname = (await File.ReadAllTextAsync($@"{container}/hostname")).Trim();
                if (!whitelistedHostNames.Contains(hostname))
                    continue;
                var files = Directory.EnumerateFiles($@"{container}/", "*json.log*", SearchOption.AllDirectories).ToList();
                var logItems = files.AsParallel().SelectMany(y =>
                {
                    var logs = File.ReadAllLines(y).Select(x => JsonSerializer.Deserialize<DockerLog>(x)).ToList();
                    foreach (var log in logs)
                        log.container = hostname;
                    return logs;
                }).OrderByDescending(x => x.time).Take(30000).ToList();
                logs.AddRange(logItems);
            }

            return new LogResponse()
            {
                Logs = logs
            };
        }
    }
}
