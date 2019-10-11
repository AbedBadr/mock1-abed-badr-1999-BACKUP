using System;
using System.IO;
using System.Net.Sockets;

namespace TCPClient
{
    class TCPClient
    {
        static void Main(string[] args)
        {
            TcpClient clientSocket = new TcpClient("127.0.0.1", 6789);
            Console.WriteLine("Client ready");

            Stream ns = clientSocket.GetStream();  //provides a Stream
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            for (int i = 0; i < 5; i++)
            {
                string message = Console.ReadLine();
                sw.WriteLine(message);

                string serverAnswer = sr.ReadLine();

                Console.WriteLine("Server: " + serverAnswer);
            }

            Console.WriteLine("No more from server. Press Enter");
            Console.ReadLine();

            ns.Close();

            clientSocket.Close();
        }
    }
}
