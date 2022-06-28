using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int PORT = 8008;
            const string IP_ADDR = "127.0.0.1";
            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse(IP_ADDR), PORT);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(iPEnd);
                Console.Write("Enter message for server:");
                string msg = Console.ReadLine();

                byte[] data = Encoding.Unicode.GetBytes(msg);
                socket.Send(data);

                byte[] buffer = new byte[256];
                StringBuilder stringBuidler = new StringBuilder();
                do
                {
                    socket.Receive(buffer);
                    stringBuidler.Append(Encoding.Unicode.GetString(buffer));
                } while (socket.Available > 0);
                Console.WriteLine(stringBuidler);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                Console.ReadLine();
            }
        }
    }
}