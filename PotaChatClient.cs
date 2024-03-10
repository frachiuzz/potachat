using System;
using System.IO;
using System.Net.Sockets;

public class Client
{
  private TcpClient client;
  private StreamReader reader;
  private StreamWriter writer;

  public Client(string serverAddress)
  {
    client = new TcpClient(serverAddress, 300);
    reader = new StreamReader(client.GetStream());
    writer = new StreamWriter(client.GetStream()) { AutoFlush = true };
  }

  public void Start()
  {
    string welcomeMessage = reader.ReadLine();
    Console.WriteLine(welcomeMessage);

    string userInput;
    do
    {
      Console.Write("Enter a message (or 'quit' to exit): ");
      userInput = Console.ReadLine();
      writer.WriteLine(userInput);
    } while (userInput != "quit");

    client.Close();
  }
}