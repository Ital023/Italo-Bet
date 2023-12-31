﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Bet.Modelos.Jogos;
using Newtonsoft.Json;

public class Baralho
{
    public bool success { get; set; }
    public string deck_id { get; set; }
    public Carta[] cards { get; set; }
    public int remaining { get; set; }

    public async Task CriarBaralho()
    {
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetStringAsync("https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1");
            var baralhoAux = JsonConvert.DeserializeObject<DeckResponse>(response);
            this.deck_id = baralhoAux.deck_id;
            this.remaining = baralhoAux.remaining;
        }
    }
    public void mostrarBaralho()
    {
        Console.WriteLine($"Deck ID: {deck_id} | restante: {remaining}");
    }

    public async Task<Carta> PuxarCarta()
    {
        using (HttpClient client = new HttpClient())
        {
            var url = $"https://deckofcardsapi.com/api/deck/{this.deck_id}/draw/?count=1";
            var response = await client.GetStringAsync(url);
            var drawResponse = JsonConvert.DeserializeObject<DeckResponse>(response);

            if (drawResponse.success)
            {
                var carta = new Carta
                {
                    value = drawResponse.cards[0].value,
                    suit = drawResponse.cards[0].suit
                };

                this.remaining = drawResponse.remaining;
                return carta;
            }
            else
            {
                return null; 
            }
        }
    }

}

