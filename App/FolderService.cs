using Autofac;
using Infra;
using System.IO;
using System.Threading;

namespace App
{
    public class FolderService
    {
        public FileSystemWatcher watcher = new FileSystemWatcher();

        private ReportService _reportService;

        public FolderService(ReportService reportService)
        {
            _reportService = reportService;
        }

        public void WatchReportFolder()
        {
            DependencyInjection.CreateContainer();

            watcher.Path = FolderPath.GetInFolderPath();
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.LastWrite;
            watcher.Filter = "*.dat";

            watcher.Created += new FileSystemEventHandler(OnChanged);

            watcher.EnableRaisingEvents = true;
        }

        public void StopWatchFolder()
        {
            watcher.EnableRaisingEvents = false;

            watcher.Changed -= new FileSystemEventHandler(OnChanged);

            watcher.Dispose();
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            Thread.Sleep(100);

            _reportService.GenerateReport();
        }
    }
}
