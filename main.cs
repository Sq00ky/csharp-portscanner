using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace csharp_portscanner
{
    class Program
    {
        static void portScan(string ipAddr, int port) {
            try
            {
                TcpClient client = new TcpClient(ipAddr, port);
                if (client.Connected) {
                    Console.WriteLine("Port " + port + " is open");
                }
            }
            catch {
                ;
            }
        }


            static int Main(string[] args) {
                if (args.Length < 3) {
                    Console.WriteLine("Not enough arguments supplied\nExample: scanner.exe 192.168.1.1 1 255");
                    return 1;
                }
                else {
                    int start, end, amount;
                    start = int.Parse(args[1]);
                    end = int.Parse(args[2]);
                    amount = end - start;

                foreach (int i in Enumerable.Range(start, amount)) {
                  Thread thread = new Thread(() => portScan(args[0], i));
                  thread.Start();
                  }
              }
              return 0;
          }
      }
  }
