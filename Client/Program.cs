using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //    const int PORT = 8008;
        //    const string IP_ADDR = "127.0.0.1";
        //    IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse(IP_ADDR), PORT);
        //    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //    try { socket.Connect(iPEnd); }
        //    catch (Exception ex) { Console.WriteLine(ex.Message); }

        //    while (true)
        //    {
        //        try
        //        {
        //            Console.Write("Enter file path:");
        //            string filePath = Console.ReadLine();
        //            if (filePath == "/end") break;
        //            if (!File.Exists(filePath)) throw new FileNotFoundException();
        //            FileInfo fileInfo = new FileInfo(filePath);
        //            socket.SendFile(fileInfo.FullName);
        //            byte[] buffer = new byte[256];
        //            StringBuilder stringBuidler = new StringBuilder();
        //            do
        //            {
        //                socket.Receive(buffer);
        //                stringBuidler.Append(Encoding.Unicode.GetString(buffer));
        //            } while (socket.Available > 0);
        //            Console.WriteLine(stringBuidler);
        //            socket.Send(Encoding.Unicode.GetBytes(fileInfo.Extension));
                    
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //    socket.Shutdown(SocketShutdown.Both);
        //    socket.Close();
        //}
    }
}