using App;
using System;

namespace net_ilg
{
    class Program
    {
        static void Main(string[] args)
        {         
            FolderService.WatchReportFolder();

            Console.WriteLine("watching folder...");
            Console.ReadLine();
        }
    }
}
