using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TCPServer
{
    class TCPServer
    {
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(6789);
            serverSocket.Start();
            Console.WriteLine("Server started");

            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Server activated");

                CalculationService calculationService = new CalculationService(connectionSocket);

                Task.Factory.StartNew(() => calculationService.DoIt());
            }
        }
    }
}
