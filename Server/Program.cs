using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace networkprogrammingtest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int PORT = 8008;
            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), PORT);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Bind(iPEnd);
                socket.Listen(10);

                Socket clientSocket = socket.Accept();
                StringBuilder stringBuilder = new StringBuilder();
                while (stringBuilder.ToString() != "/end")
                {
                    int byteCount = 0;
                    byte[] buffer = new byte[256];
                    do
                    {
                        byteCount = clientSocket.Receive(buffer);
                        stringBuilder.Append(Encoding.Unicode.GetString(buffer, 0, byteCount));
                    } while (clientSocket.Available > 0);

                    Console.WriteLine($"Client msg:{stringBuilder}");

                    clientSocket.Send(Encoding.Unicode.GetBytes("Message recieved!"));
                    stringBuilder.Clear();
                }
                Console.ReadKey();
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();

            }
            catch { }
            finally
            {
            }
        }
    }
}
