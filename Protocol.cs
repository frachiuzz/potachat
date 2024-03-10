using System;
using System.Collections.Generic;

namespace Potachat;
public class Protocol
{
  // lista dei comandi validi
  private static List<string> validCommands = new List<string> { "HELLO", "NAME", "LIST", "MESSAGE", "QUIT" };

  // Costruttore della classe
  public Protocol()
  {

  }

  // Metodo per decodificare una stringa come comando Potachat e restituire un'istanza di classe Command
  public Command DecodePotachatCommand(string input)
  {
    string command;

    // Divido la stringa in comando e parametri
    string[] parts = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    // se c'è almeno un elemento e il primo elemento è un comando valido
    if (parts.Length > 0 && validCommands.Contains(parts[0]))
    {
      command = parts[0];
      string[] parameters = parts.Length > 1 ? parts[1..] : Array.Empty<string>();
      return new Command()
      {
        IsValidCommand = true,
        CmdName = command,
        CmdParameters = parameters
      };
    }
    return null;
  }

}
