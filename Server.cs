using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Potachat;

public class Server
{
  private IPAddress address;
  private int port;
  private int clientsNum;

  private IPEndPoint endPoint;
  private TcpListener listener;

  private Dictionary<int, TcpClient> clients = new Dictionary<int, TcpClient>();
  private NetworkStream stream;

  public Server(IPAddress address, int port)
  {
    this.address = address;
    this.port = port;
    this.clientsNum = 0;
  }

  public void Init()
  {
    try
    {
      endPoint = new IPEndPoint(this.address, this.port);
      listener = new(endPoint);
      listener.Start();

      while (true)
      {
        TcpClient client = listener.AcceptTcpClient();
        clients.Add(++this.clientsNum, client);

        Thread thread = new Thread(HandleClients);
        thread.Start(clientsNum);

        Console.WriteLine($"Client connected ( ip: {this.address} | port: {this.port} | id {clientsNum} | client: {client} )");
      }
    }
    catch (Exception e)
    {
      Console.WriteLine($"Exception: {e.Message}");
    }
  }

  public void HandleClients(object idObj)
  {
    int id = (int)idObj;

    TcpClient client = clients[id];

    while (true)
    {
      NetworkStream nStream = client.GetStream();

      var buf = new byte[1024];
      int sizeBuf = nStream.Read(buf, 0, buf.Length);

      if (sizeBuf == 0) break;

      string data = Encoding.UTF8.GetString(buf, 0, sizeBuf);

      Console.WriteLine($"Data Received: {data} | id: {id} | client: {client}");

      Broadcast(data, id);
    }

    clients.Remove(id);
    client.Client.Shutdown(SocketShutdown.Both);
    client.Close();
    Console.WriteLine($"Client disconnected ( id: {id} )");
  }

  public void Broadcast(string data, int id)
  {
    var buf = Encoding.UTF8.GetBytes(data);

    foreach (var client in clients)
    {
      if (client.Key != id)
      {
        NetworkStream stream = client.Value.GetStream();
        stream.Write(buf, 0, buf.Length);
      }
    }
  }
}