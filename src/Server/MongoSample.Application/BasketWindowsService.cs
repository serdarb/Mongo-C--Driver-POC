using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace MongoSample.Application
{
    partial class BasketWindowsService : ServiceBase
    {
        public BasketWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Bootstrapper.Initialize();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
