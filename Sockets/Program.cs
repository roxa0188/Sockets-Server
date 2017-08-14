using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace Sockets
{
    class Program
    {
        private static bool programRunning = true;

        public static void Ex23(StreamWriter sw, StreamReader sr)
        {
            
            while (programRunning)
            {
                sw.WriteLine("ready");
                string data = sr.ReadLine();

                switch (data)
                {
                    default: sw.WriteLine("Unknown command!"); break;
                    case "time?": sw.WriteLine(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second); break;
                    case "date?": sw.WriteLine(DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year); break;

                }
            }
        }
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Any;
            TcpListener listener = new TcpListener(ip,5000);
            listener.Start();

            while(programRunning)
            {
                TcpClient client = listener.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());
                StreamWriter sw = new StreamWriter(client.GetStream());
                sw.AutoFlush = true;

                Thread clientThread = new Thread(() => Ex23(sw, sr));
                clientThread.Start();

                //Ex23(sw, sr);
                //Ex4
                //bool active = true;
                //while (active)
                //{
                //    sw.WriteLine("ready");
                //    string data = sr.ReadLine();

                //    if(data=="exit")
                //    {
                //        active = false;
                //    }
                //    else
                //    {
                //        string[] input = data.Split(' ');
                //        int x = int.Parse(input[1]);
                //        int y = int.Parse(input[2]);

                //        switch (input[0])
                //        {
                //            case "add":
                //                int sum = x + y;
                //                sw.WriteLine("sum " + sum); break;

                //            case "sub":
                //                int diff = x - y;
                //                sw.WriteLine("difference" + diff); break;
                //        }
                //    }


                //}

                //Ex2&3
                

                //Ex1
                //IPEndPoint ip = (IPEndPoint)client.Client.RemoteEndPoint;
                //Console.WriteLine("Client: " + ip.Address.ToString() + ":" + ip.Port.ToString());


                //    sw.WriteLine("Hello client");


            }
        }
    }
}
