using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using DataAccessLayer.Concrete;
using System.Text;
using System.Threading.Tasks;
using MyWalletService;

namespace MyWalletService1
{

    public partial class Service1 : ServiceBase
    {
        Timer timer = null;
        public Service1()
        {
            InitializeComponent();
            ServiceName = "MyWalletService";
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer(Process, null, 60000, Timeout.Infinite);
        }

        protected override void OnStop()
        {
            timer.Dispose();
        }
        public void Process(Object source)
        {

            RepetitiveToTransactions transactions = new RepetitiveToTransactions();
            transactions.Main();

            if (timer != null)
                timer.Change(60000, Timeout.Infinite);
        }
    }
}
