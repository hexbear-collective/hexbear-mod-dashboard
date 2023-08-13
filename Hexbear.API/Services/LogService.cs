﻿using Hexbear.Lib.Models;
using System.Text.Json;

namespace Hexbear.API.Services
{
    public class LogService
    {
        public async Task<LogResponse> ListLogs()
        {
            //Get logs from volume within container
            var directory = $@"{Directory.GetCurrentDirectory()}\Logs\";
#if DEBUG
            directory = $@"{Directory.GetCurrentDirectory()}\bin\Debug\net7.0\Logs\";
#endif
            var logs = new List<DockerLog>();
            var containers = Directory.EnumerateDirectories(directory);
            foreach (var container in containers)
            {
                string hostname = File.ReadAllText($@"{container}/hostname");
                var files = Directory.EnumerateFiles($@"{container}/", "*json.log*", SearchOption.AllDirectories).ToList();
                var logItems = files.SelectMany(y =>
                {
                    var logs = File.ReadAllLines(y).Select(x => JsonSerializer.Deserialize<DockerLog>(x)).ToList();
                    var filename = new FileInfo(y).Name;
                    foreach (var log in logs)
                        log.container = hostname;
                    return logs;
                }).OrderByDescending(x => x.time).ToList();
                logs.AddRange(logItems);
            }

            return new LogResponse()
            {
                Logs = logs
            };
        }
    }
}