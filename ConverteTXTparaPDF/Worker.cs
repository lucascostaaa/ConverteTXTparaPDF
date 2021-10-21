using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TXT_to_PDF;

namespace ConverteTXTparaPDF
{
    public class Worker : BackgroundService
    {
        public static ILogger<Worker> Logger;
        private readonly FileSystemWatcher Watcher;

        public Worker(ILogger<Worker> logger)
        {
            Logger = logger;
            Watcher = FileWatcher.Configure();

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
