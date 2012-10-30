namespace MongoSample.Application
{
    using System.ComponentModel;
    using System.ServiceProcess;

    [RunInstaller(true)]
    public partial class EasyInstaller : System.Configuration.Install.Installer
    {
        private readonly ServiceProcessInstaller _serviceProcess;
        private readonly ServiceInstaller _serviceInstaller;

        public EasyInstaller()
        {
            InitializeComponent();

            _serviceProcess = new ServiceProcessInstaller { Account = ServiceAccount.NetworkService };
            _serviceInstaller = new ServiceInstaller
            {
                ServiceName = "MongoSampleBasketService",
                DisplayName = "MongoSample Basket Service",
                Description = "MongoSample Basket Service",
                StartType = ServiceStartMode.Automatic
            };
            Installers.Add(_serviceProcess);
            Installers.Add(_serviceInstaller);
        }
    }
}
