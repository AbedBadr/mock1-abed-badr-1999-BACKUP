using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
{
    class NewTCPClient
    {
        static void Main(string[] args)
        {
            TcpClient clientSocket = new TcpClient("127.0.0.1", 6789);
            Console.WriteLine("Client ready");

            Stream ns = clientSocket.GetStream();  //provides a Stream
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            Console.WriteLine("Indtast personbil eller elbil");

            int count = 0;
            while (count++ < 6)
            {
                string message = Console.ReadLine();
                sw.WriteLine(message);

                string serverMessage = sr.ReadLine();

                Console.WriteLine("Server: " + serverMessage);
            }

            Console.WriteLine("No more from server. Press Enter");
            Console.ReadLine();

            ns.Close();
            clientSocket.Close();
        }
    }
}
