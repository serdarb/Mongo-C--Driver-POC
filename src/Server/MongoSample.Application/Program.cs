using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

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
