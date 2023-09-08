using System.Text.Json.Serialization;

namespace Bet.Modelos.Jogos;
public class Carta
{
    public bool success { get; set; }
    public string value { get; set; }
    public string suit { get; set; }

    public string getValue()
    {
        return value;
    }

    public string getSuit()
    {
        return suit;
    }

}
