using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MongoSample.Contract;
using MongoSample.Web.Controllers;

namespace MongoSample.Web.App_Start
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var netNamedPipeBinding = new NetNamedPipeBinding
            {
                MaxBufferSize = 67108864,
                MaxReceivedMessageSize = 67108864,
                TransferMode = TransferMode.Streamed,
                ReceiveTimeout = new TimeSpan(0, 30, 0),
                SendTimeout = new TimeSpan(0, 30, 0)
            };

            container.AddFacility<WcfFacility>();
            container.Register(Component.For<IBasketService>()
                     .AsWcfClient(new DefaultClientModel { Endpoint = WcfEndpoint.BoundTo(netNamedPipeBinding).At("net.pipe://localhost/BasketService") })
                     .LifestylePerWebRequest());
        }
    }

    public class ControllerInstaller
    {
        public class ControllersInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(Types.FromThisAssembly()
                                    .Pick().If(Component.IsInSameNamespaceAs<HomeController>())
                                    .If(t => t.Name.EndsWith("Controller"))
                                    .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                                    .LifestylePerWebRequest());
            }
        }
    }
}