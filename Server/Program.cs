using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int PORT = 8008;

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), PORT);
            Socket clientSocket = null;
            try
            {
                socket.Bind(iPEnd);
                socket.Listen();
                clientSocket = socket.Accept();

                if (!Directory.Exists("Files")) Directory.CreateDirectory("Files");
                while (true)
                {
                    string messageType = ReceiveString(clientSocket);
                    if (messageType == "file")
                    {
                        clientSocket.Send(Encoding.Unicode.GetBytes("message type confirmed"));
                        string extenstion = ReceiveString(clientSocket);
                        clientSocket.Send(Encoding.Unicode.GetBytes("extension confirmed"));

                        File.WriteAllBytes($"Files\\{GenerateFileName(extenstion)}", ReceiveFile(clientSocket));
                        Console.WriteLine("file created");
                    }
                    else if (messageType == "text")
                    {
                        clientSocket.Send(Encoding.Unicode.GetBytes("message type confirmed"));

                        File.WriteAllText($"Files\\{GenerateFileName(".txt")}", ReceiveString(clientSocket));
                        Console.WriteLine("text file created");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                clientSocket.Shutdown(SocketShutdown.Both);
            }
        }
        static string ReceiveString(Socket clientSocket)
        {
            byte[] buffer = new byte[256];
            int byteCount = 0;
            StringBuilder sb = new StringBuilder();
            do
            {
                byteCount = clientSocket.Receive(buffer);
                sb.Append(Encoding.Unicode.GetString(buffer, 0, byteCount));
                if (byteCount == 0) continue;
            } while (clientSocket.Available > 0);

            return sb.ToString();
        }
        static byte[] ReceiveFile(Socket clientSocket)
        {
            byte[] buffer = new byte[256];
            int byteCount = 0;
            List<byte> bytes = new List<byte>();
            StringBuilder sb = new StringBuilder();
            do
            {
                byteCount = clientSocket.Receive(buffer);
                bytes.AddRange(buffer);
            } while (clientSocket.Available > 0);
            return bytes.ToArray();
        }
        static string GenerateFileName(string extenstion)
        {
            string fileName = $"ReceivedText{extenstion}";
            int counter = 0;
            while (true)
            {
                if (!File.Exists($"Files\\{fileName}")) return fileName;
                else fileName = $"ReceivedFile({counter}){extenstion}";
                counter++;
            }
        }
    }
}
