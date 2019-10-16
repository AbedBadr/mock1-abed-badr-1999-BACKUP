using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Skat;

namespace TCPServer
{
    class Service
    {
        private TcpClient _connectionSocket;

        public Service(TcpClient connection)
        {
            _connectionSocket = connection;
        }

        public void DoIt()
        {
            Stream ns = _connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            string message = sr.ReadLine();

            while (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine("Client: " + message);
                string answer;

                if (message == "Personbil" || message == "personbil")
                {
                    answer = "Indtast pris";
                    sw.WriteLine(answer);

                    message = sr.ReadLine();

                    try
                    {
                        int pris = Convert.ToInt32(message);

                        Afgift afgift = new Afgift();

                        string regAfgift = afgift.BilAfgift(pris).ToString() + " kr.";
                        answer = ("Registreringsafgiften er: " + regAfgift);
                        sw.WriteLine(answer);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Formattet er ikke tal", e.Message);
                    }
                    finally
                    {
                        answer = "Formattet kan kun være tal";
                        sw.WriteLine(answer);
                    }
                }

                if (message == "Elbil" || message == "elbil")
                {
                    answer = "Indtast pris";
                    sw.WriteLine(answer);

                    message = sr.ReadLine();

                    try
                    {
                        int pris = Convert.ToInt32(message);

                        Afgift afgift = new Afgift();

                        string regAfgift = afgift.ElBilAfgift(pris).ToString() + " kr.";
                        answer = ("Registreringsafgiften er: " + regAfgift);
                        sw.WriteLine(answer);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Formattet er ikke tal", e.Message);
                    }
                    finally
                    {
                        answer = "Formattet kan kun være tal";
                        sw.WriteLine(answer);
                    }
                }
                else
                {
                    answer = "Du skal indtaste personbil eller elbil";
                    sw.WriteLine(answer);
                }

                message = sr.ReadLine();
            }
        }
    }
}
