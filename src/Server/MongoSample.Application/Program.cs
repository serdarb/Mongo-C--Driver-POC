using System;
using System.ServiceProcess;

namespace MongoSample.Application
{
    class Program
    {
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                Bootstrapper.Initialize();
                Console.WriteLine("MongoSample Basket Server is ready!");
                Console.ReadLine();
            }
            else
            {
                ServiceBase.Run(new ServiceBase[] { new BasketWindowsService() });
            }
        }
    }
}
