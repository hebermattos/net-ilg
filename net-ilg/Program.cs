using App;
using Autofac;
using Infra;
using System;
using System.IO;

namespace net_ilg
{
    class Program
    {
        static void Main(string[] args)
        {
            DependencyInjection.CreateContainer();

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = FolderPath.GetInFolderPath();

            watcher.Filter = "*.dat";

            watcher.Created += new FileSystemEventHandler(OnChanged);

            watcher.EnableRaisingEvents = true;

            Console.WriteLine("watching...");
            Console.ReadLine();

        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("New file to update report: " + e.FullPath);

            using (var scope = DependencyInjection.Container.BeginLifetimeScope())
            {
                var reportService = scope.Resolve<ReportService>();

                reportService.GenerateReport();
            }
        }
    }
}
