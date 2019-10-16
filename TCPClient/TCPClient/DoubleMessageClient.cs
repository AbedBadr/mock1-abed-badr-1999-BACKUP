using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
{
    class DoubleMessageClient
    {
        static void Main1(string[] args)
        {
            TcpClient clientSocket = new TcpClient("127.0.0.1", 6789);
            Console.WriteLine("Client ready");

            Stream ns = clientSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            Console.WriteLine("Indtast Personbil eller Elbil");

            int count = 0;
            while (count++ < 2)
            {
                string messageCarType = Console.ReadLine();
                Console.WriteLine("Indtast pris (kun tal)");
                string messagePrice = Console.ReadLine();

                sw.WriteLine(messageCarType);
                sw.WriteLine(messagePrice);

                string serverAnswer = sr.ReadLine();
                Console.WriteLine("Server: " + serverAnswer);
            }

            Console.WriteLine("No more from server. Press Enter");
            Console.ReadKey();

            ns.Close();
            clientSocket.Close();
        }
    }
}
