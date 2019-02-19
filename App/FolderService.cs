using Autofac;
using Infra;
using System.IO;

namespace App
{
    public static class FolderService
    {
       public static FileSystemWatcher watcher = new FileSystemWatcher();

        public static void WatchReportFolder()
        {
            DependencyInjection.CreateContainer();
          
            watcher.Path = FolderPath.GetInFolderPath();
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.LastWrite;
            watcher.Filter = "*.dat";

            watcher.Created += new FileSystemEventHandler(OnChanged);

            watcher.EnableRaisingEvents = true;
        }

        public static void StopWatch()
        {
            watcher.EnableRaisingEvents = false;

            watcher.Changed -= new FileSystemEventHandler(OnChanged);

            watcher.Dispose();
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            using (var scope = DependencyInjection.Container.BeginLifetimeScope())
            {
                var reportService = scope.Resolve<ReportService>();

                reportService.GenerateReport();
            }
        }
    }
}
