using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PortPinger
{
    class Program
    {

        private static string _address;
        private static Dictionary<int, bool> _openPorts;
        private static double _counter = 0.0;

        static void Main(string[] args)
        {

            Console.Write("I want to check the ports of: ");
            _address = Console.ReadLine();
            _openPorts = new Dictionary<int, bool>();

            var ports = Enumerable.Range(1, 1023).ToList();

            Parallel.ForEach(ports, (port) =>
            {

                _counter++;
                double percent = _counter / 1023.0;
                _openPorts.Add(port, Ping(port));
                //Console.Write($"\r{percent}% done");

            });

        }

        static bool Ping(int port)
        {

            using (var client = new TcpClient() { ReceiveTimeout = 1, SendTimeout = 1})
            {

                try
                {

                    client.Connect(_address, port);
                    //Console.WriteLine($"{port} is open.");
                    return true;

                }
                catch
                {

                    //Console.WriteLine($"{port} is closed");
                    return false;

                }

            }

        }
    }
}
