using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // (1)
            Socket servSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // (2)
            IPAddress ipaddr = IPAddress.Any;
            IPEndPoint ipep = new IPEndPoint(ipaddr, 23000);
            servSocket.Bind(ipep);

            // (3)
            servSocket.Listen(5);
            Console.WriteLine("Server listening on: " + servSocket.LocalEndPoint?.ToString());
            Console.WriteLine("Waiting for incoming connection...");

            // (4)
            Socket connSocket = servSocket.Accept();

            // + 추가

            Console.WriteLine("Client connected. " + connSocket.ToString() + " - IP End Point: " + connSocket.RemoteEndPoint?.ToString());

            // (5)
            byte[] buff = new byte[128];

            int numberOfReceivedBytes = 0;
            numberOfReceivedBytes = connSocket.Receive(buff);

            Console.WriteLine("Number of received bytes: " + numberOfReceivedBytes);
            Console.WriteLine("Data sent by client is: " + buff);

            string receivedText = Encoding.ASCII.GetString(buff, 0, numberOfReceivedBytes);

            Console.WriteLine("Data sent by client is: " + receivedText);
        }
    }
}