using System.Text.Json.Serialization;

namespace Bet.Modelos.Jogos;

internal class Baralho
{
    [JsonPropertyName("deck_id")]
    public string IdDeck { get; set; }

    [JsonPropertyName("remaining")]
    public string cartasRestantes { get; set; }

    public string GetIdDeck()
    {
        return IdDeck;
    }

    public string GetRemaining()
    {
        return cartasRestantes;
    }


}
