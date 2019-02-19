﻿using Autofac;
using Infra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public static class FolderService
    {
        public static void WatchFolder()
        {
            DependencyInjection.CreateContainer();

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = FolderPath.GetInFolderPath();
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.LastWrite;
            watcher.Filter = "*.dat";

            watcher.Created += new FileSystemEventHandler(OnChanged);

            watcher.EnableRaisingEvents = true;
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
