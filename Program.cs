using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace tcpconnect
{
    class Program
    {
        static void Main(string[] args)
        {
            Connect("127.0.0.1", 9090);
            Console.Read();
        }

        public static void Connect(string host, int port)
        {
            IPAddress[] IPs = Dns.GetHostAddresses(host);

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Establishing Connection to {0}", host);
            s.Connect(IPs[0], port);

            byte[] msgBytes = Encoding.ASCII.GetBytes("Message from client");
            s.Send(msgBytes);

            byte[] buffer = new byte[50];
            s.Receive(buffer);

            Console.Write("Message from server is: " + Encoding.ASCII.GetString(buffer));
        }
    }
}