using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Timers;

namespace MyWalletService
{
    public class Program
    {
        Context DbContext = new Context();
        public const string ServiceName = "MyWalletService";

        public class Service : ServiceBase
        {

            
            Timer timer = new Timer();
            public Service()
            {
                
                ServiceName = Program.ServiceName;
            }

            protected override void OnStart(string[] args)
            {
                RepetitiveToTransactions transactions = new RepetitiveToTransactions();
                //tick
                timer.Interval = 1000 * 10;
                timer.Enabled = true;
                timer.Start();               
                timer.Elapsed += transactions.Main;
                //Program.Start(args);
            }

            protected override void OnStop()
            {

                //release
                timer.Dispose();
                
                //Program.Stop();
            }
        }



        static void Main(string[] args)
        {

            if (!Environment.UserInteractive)
                // running as service
                using (var service = new Service())
                    ServiceBase.Run(service);
            else
            {
                // running as console app
                Start(args);

                Console.WriteLine("Press any key to stop...");
                Console.ReadKey(true);

                Stop();
            }
        }
        public static void Start(string[] args)
        {
            
        }

        private static void Stop()
        {
            // onstop code here
        }
    }
}
