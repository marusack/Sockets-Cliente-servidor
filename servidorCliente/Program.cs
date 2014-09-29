using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

//sack ceppi mariel rocio
namespace servidor
{
    class Program
    {
        static byte[] Buffer { get; set; }
        static Socket sck;
        static void Main(string[] args)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(IPAddress.Any,1234));
            sck.Listen(100);

            Socket accepted = sck.Accept();//espera a q conecte alguien
            Buffer = new byte[accepted.SendBufferSize];

            //procedemos a recibir

            int bytesRecibidos = accepted.Receive(Buffer);//numero de bites q vamos a enviar
            //damos formato al buffer
            byte[] formatted = new byte[bytesRecibidos];
            for (int i = 0; i < bytesRecibidos; i++)
            {
                //esto se hace para evitar q en la trasferencia entren datos "basura"
                formatted[i] = Buffer[i];
            }
            //procedo a escribir la informacion en la consola
            String strData = Encoding.ASCII.GetString(formatted);
            Console.Write(strData + "\r\n");
            Console.Read();
            sck.Close();
            accepted.Close();
        }
    }
}
