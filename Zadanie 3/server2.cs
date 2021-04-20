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
                string data = null;
                int listenPort = 11000;
				UdpClient listener = new UdpClient(listenPort);
				IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
                try
                {
					while (true){
								Console.WriteLine("Waiting for broadcast");
								byte[] bytes = listener.Receive(ref groupEP);
								Console.WriteLine($"Received broadcast from {groupEP} :");								         
								data = BitConverter.ToString(bytes);
								Console.WriteLine($"Received {data}");	
								string path = Thread.CurrentThread.ManagedThreadId + ".txt";
								using (StreamWriter sw = File.CreateText(path))
                            {
                                sw.WriteLine(data);
                            }
								}
                }
                        catch (SocketException e)
                        {
                            Console.WriteLine(e));
                        }
						finally
						{
							listener.Close();
                    }
			}
                
           static void client2()
            {                
                string data = null;
                int listenPort = 12000;
				UdpClient listener = new UdpClient(listenPort);
				IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
                try
                {
					while (true){
								Console.WriteLine("Waiting for broadcast");
								byte[] bytes = listener.Receive(ref groupEP);
								Console.WriteLine($"Received broadcast from {groupEP} :");								         
								data = BitConverter.ToString(bytes);
								Console.WriteLine($"Received {data}");	
								string path = Thread.CurrentThread.ManagedThreadId + ".txt";
								using (StreamWriter sw = File.CreateText(path))
                            {
                                sw.WriteLine(data);
                            }
								}
                }
                        catch (SocketException e)
                        {
                            Console.WriteLine(e));
                        }
						finally
						{
							listener.Close();
                    }
			}
        

    }
}
