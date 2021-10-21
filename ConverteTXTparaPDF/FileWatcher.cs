using ConverteTXTparaPDF;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace TXT_to_PDF
{
    public class FileWatcher
    {
        private static ILogger<Worker> Logger = Worker.Logger;

        public static FileSystemWatcher Configure()
        {
            Logger.LogInformation("Configurando Watcher:{time}", DateTimeOffset.Now.TimeOfDay);

            var watcher = new FileSystemWatcher(JsonConfig.PastaWatcher);

            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Created += OnCreated;
            watcher.InternalBufferSize = 65536;
            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            return watcher;
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Logger.LogInformation("Txt encontrado {arquivo} :{time}", e.Name, DateTimeOffset.Now.TimeOfDay);

            Task.Run(() => ConverteTXT.Converter(new FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)));
        }
    }
}
