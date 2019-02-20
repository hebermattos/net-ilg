using App;
using Autofac;
using System;

namespace net_ilg
{
    class Program
    {
        static void Main(string[] args)
        {
            DependencyInjection.CreateContainer();

            using (var scope = DependencyInjection.Container.BeginLifetimeScope())
            {
                var folderService = scope.Resolve<FolderService>();

                folderService.WatchReportFolder();
            }

            Console.WriteLine("watching folder...");
            Console.ReadLine();
        }
    }
}
