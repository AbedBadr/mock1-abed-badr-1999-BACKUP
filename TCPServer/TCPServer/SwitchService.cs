using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Skat;

namespace TCPServer
{
    class SwitchService
    {
        private TcpClient _connectionSocket;

        public SwitchService(TcpClient connection)
        {
            _connectionSocket = connection;
        }

        public void DoIt()
        {
            try
            {
                Stream ns = _connectionSocket.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;
                Afgift afgift = new Afgift();

                string messageCarType = sr.ReadLine();
                string messagePrice = sr.ReadLine();
                int price = Convert.ToInt32(messagePrice);
                string answer;

                switch (messageCarType)
                {
                    case "Personbil":
                    {
                        string regAfgift = afgift.BilAfgift(price).ToString();
                        answer = "Registreringsafgiften er: " + regAfgift;
                        sw.WriteLine(answer);
                        break;
                    }
                    case "Elbil":
                    {
                        string regAfgift = afgift.ElBilAfgift(price).ToString();
                        answer = "Registreringsafgiften er: " + regAfgift;
                        sw.WriteLine(answer);
                        break;
                    }
                    default:
                    {
                        answer = "Du skal skrive Personbil eller Elbil";
                        sw.WriteLine(answer);
                        break;
                    }
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format is not number", e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Argument cant be null or empty", e.Message);
            }
        }
    }
}
