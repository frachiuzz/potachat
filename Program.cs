using System.Net;

namespace Potachat;

class Program
{
  static void Main(string[] args)
  {
    if (args.Length > 0 && args[0] == "server")
    {
      Server tcpServer = new Server(IPAddress.Any, 300);
      tcpServer.Init();
    }
    else if (args.Length > 0 && args[0] == "client")
    {
      Client client = new Client(args[1]);
      client.Start();
    }
    else
    {
      Console.WriteLine("Specify 'server' or 'client' as the first argument. If you choose 'client', specify the server address as the second argument.");
    }
  }
}
