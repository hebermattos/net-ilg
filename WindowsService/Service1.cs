using App;
using Autofac;
using System.ServiceProcess;

namespace WindowsService
{

    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        private FolderService folderService;
        private ILifetimeScope scope;

        protected override void OnStart(string[] args)
        {
            DependencyInjection.CreateContainer();

            scope = DependencyInjection.Container.BeginLifetimeScope();

            folderService = scope.Resolve<FolderService>();

            folderService.WatchReportFolder();

        }

        protected override void OnStop()
        {
            folderService.StopWatchFolder();

            scope.Dispose();
        }
    }
}
