using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Skat;

namespace TCPServer
{
    class DoubleMessageService
    {
        private TcpClient _connectionSocket;

        public DoubleMessageService(TcpClient connection)
        {
            _connectionSocket = connection;
        }

        public void DoIt()
        {
            Stream ns = _connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            Afgift afgift = new Afgift();

            string messageCarType = sr.ReadLine();
            string messagePrice = sr.ReadLine();

            while (!string.IsNullOrEmpty(messageCarType))
            {
                Console.WriteLine("Client: " + messageCarType);
                string answer;

                if (messageCarType == "Personbil" || messageCarType == "personbil")
                {
                    try
                    {
                        int pris = Convert.ToInt32(messagePrice);

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

                if (messageCarType == "Elbil" || messageCarType == "elbil")
                {
                    try
                    {
                        int pris = Convert.ToInt32(messagePrice);

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

                messageCarType = sr.ReadLine();
            }
        }
    }
}
