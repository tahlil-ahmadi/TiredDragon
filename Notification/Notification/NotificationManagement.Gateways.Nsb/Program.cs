using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationManagement.Gateways.Nsb
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var bus = BusConfig.Config();

            Console.WriteLine("Notification is running !");
            Console.ReadLine();
        }
    }
}
