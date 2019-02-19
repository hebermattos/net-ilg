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
            FolderService.WatchFolder();

            Console.WriteLine("watching...");
            Console.ReadLine();
        }
    }
}
