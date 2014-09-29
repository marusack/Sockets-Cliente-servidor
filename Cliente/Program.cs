using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Cliente
{
    class Program
    {
        static Socket sck;

        static void Main(string[] args)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            try {
                sck.Connect(localEndPoint);
                

            }
            catch {
                Console.Write("imposible establecer conexion con el end point .... sorry");
                Main(args);
            }
            Console.Write("ingresa el texto:");
            string text = Console.ReadLine();
            byte[] info = Encoding.ASCII.GetBytes(text);
            sck.Send(info);
            Console.Write("informacion enviada... !");
            Console.Write("presiona cualquier tecla para continuar");
            Console.Read();
            sck.Close();
        }
    }
}
