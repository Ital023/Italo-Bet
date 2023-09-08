using Bet.Modelos.Jogos;

public class DeckResponse
{
    public bool success { get; set; }
    public string deck_id { get; set; }
    public Carta[] cards { get; set; }
    public int remaining { get; set; }
}