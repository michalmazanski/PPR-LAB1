using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace socket
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread watek1 = new Thread(client1);
            watek1.Start();

            Thread watek2 = new Thread(client2);
            watek2.Start();
        }

            static void client1()
            {
                byte[] bytes = new Byte[1024];
                string data = null;
                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 11000);
                Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(10);
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Waiting for a connection...");
                            Socket handler = listener.Accept();
                            Console.WriteLine($"Connection from {handler.RemoteEndPoint.ToString()}");
                            handler.Receive(bytes);
                            data = BitConverter.ToString(bytes);
                            string path = Thread.CurrentThread.ManagedThreadId + ".txt";
                            using (StreamWriter sw = File.CreateText(path))
                            {
                                sw.WriteLine(data);
                            }
                            handler.Shutdown(SocketShutdown.Both);
                            handler.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                Console.WriteLine("\nPress ENTER to continue...");
                Console.Read();
            }
            static void client2()
            {
                byte[] bytes = new Byte[1024];
                string data = null;
                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 12000);
                Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(10);
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Waiting for a connection...");
                            Socket handler = listener.Accept();
                            Console.WriteLine($"Connection from {handler.RemoteEndPoint.ToString()}");
                            handler.Receive(bytes);
                            data = BitConverter.ToString(bytes);
                            string path = Thread.CurrentThread.ManagedThreadId + ".txt";
                            using (StreamWriter sw = File.CreateText(path))
                            {
                                sw.WriteLine(data);
                            }
                            handler.Shutdown(SocketShutdown.Both);
                            handler.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                Console.WriteLine("\nPress ENTER to continue...");
                Console.Read();
            }
        

    }
}
