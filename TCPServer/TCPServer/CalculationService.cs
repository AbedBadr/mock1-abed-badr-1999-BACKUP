using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using Skat;

namespace TCPServer
{
    class CalculationService
    {
        private TcpClient _connectionSocket;

        public CalculationService(TcpClient connection)
        {
            _connectionSocket = connection;
        }

        public void DoIt()
        {
            Stream networkStream = _connectionSocket.GetStream();
            StreamReader sr = new StreamReader(networkStream);
            StreamWriter sw = new StreamWriter(networkStream);
            sw.AutoFlush = true; // enable automatic flushing

            string message = sr.ReadLine();
            string answer = "";
            while (message != null && message != "")
            {
                Console.WriteLine("Client: " + message);
                if (message == "Personbil")
                {
                    answer = "Indtast pris";
                    sw.WriteLine(answer);

                    message = sr.ReadLine();
                    int pris = Convert.ToInt32(message);

                    Afgift afgift = new Afgift();

                    answer = afgift.BilAfgift(pris).ToString();
                    sw.WriteLine(answer);
                }

                if (message == "Elbil" || message == "elbil")
                {
                    answer = "Indtast pris:";
                    sw.WriteLine(answer);

                    message = sr.ReadLine();
                    
                    try
                    {
                        int pris = Convert.ToInt32(message);

                        Afgift afgift = new Afgift();

                        answer = ("Elbil afgiften er: " + afgift.ElBilAfgift(pris).ToString());
                        sw.WriteLine(answer);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Svar skal kun være tal", e.Message);
                    }

                }

                else
                {
                    answer = "Du skal indtaste personbil eller elbil";
                    sw.WriteLine();

                    
                }
                message = sr.ReadLine();
            }
        }
    }
}
