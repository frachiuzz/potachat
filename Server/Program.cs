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
    else if (args.Length > 0 && args[0] == "client")
    {
      PotaChatClient client = new PotaChatClient(args[1]);
      client.Start();
    }
    else
    {
      Console.WriteLine("Specify 'server' or 'client' as the first argument. If you choose 'client', specify the server address as the second argument.");
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