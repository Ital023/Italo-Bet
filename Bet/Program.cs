using Bet.Modelos.Jogos;
using System.Net.Http.Json;
using System.Text.Json;

using (HttpClient client = new HttpClient())
{

    try
    {
        string reposta = await client.GetStringAsync("https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1");

        var baralho = JsonSerializer.Deserialize<Baralho>(reposta);

        Console.WriteLine(baralho);

    }
    catch (Exception ex)
    {
        Console.WriteLine("O programa não rodou pois: " + ex.Message);

    }
}