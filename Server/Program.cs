using System.Net;
using System.Net.Sockets;
using System.Text;
using ConsoleApp1.server;

public class Program
{
  public static void Main(string[] args)
  {
    if (args.Length > 0 && args[0] == "server")
    {
      TcpServer tcpServer = new TcpServer(IPAddress.Any, 300);
      tcpServer.Init();
    }
    else
    {
    }

  }
}



/*
var ipEndPoint = new IPEndPoint(IPAddress.Any, 300);
TcpListener listener = new(ipEndPoint);

try
{
    listener.Start();

    using TcpClient handler = await listener.AcceptTcpClientAsync();
    await using NetworkStream stream = handler.GetStream();

    while (true)
    {
        var buf = new byte[1_024];
        int recvSize = await stream.ReadAsync(buf);

        if (recvSize != 0)
        {
            var msg = Encoding.UTF8.GetString(buf, 0, recvSize);

            Console.WriteLine($"Received: {msg} | recv status: {recvSize}");
        }
    }
}
finally
{
    listener.Stop();
}*/