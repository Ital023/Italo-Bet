using Bet.Modelos.Jogos.BlackJackk;
using Bet.Modelos.Jogos;

namespace Bet.Modelos.Jogos;

public class BlackJack
{
    public async Task CriarMesa(Dealer dealer,Cliente cliente,Baralho baralho)
    {
        if(dealer.MaoDealer.Count <= 0 || cliente.MaoCliente.Count <= 0)
        {
            for(int i = 0;i < 2; i++)
            {
                Carta cartaCliente = await baralho.PuxarCarta();
                cliente.addCarta(cartaCliente);

                Carta cartaDealer = await baralho.PuxarCarta();
                dealer.addCarta(cartaDealer);
            }
        }
    }

    public int ValorCartasDealer(Dealer dealer)
    {
        int somaDealer = 0;

        foreach (var carta in dealer.MaoDealer)
        {
            if (carta.getValue() == "KING" || carta.getValue() == "JACK" || carta.getValue() == "QUEEN")
            {
                somaDealer += 10;
            }
            else if (carta.getValue() == "ACE")
            {
                if (somaDealer >= 11)
                {
                    somaDealer += 1;
                }
                else
                {
                    somaDealer += 11;
                }
            }
            else
            {
                somaDealer += int.Parse(carta.getValue());
            }
        }

        return somaDealer;
    }


    public int ValorCartaJogador(Cliente cliente)
    {
        int somaCliente = 0;

        foreach (var carta in cliente.MaoCliente)
        {
            if (carta.getValue() == "KING" || carta.getValue() == "JACK" || carta.getValue() == "QUEEN")
            {
                somaCliente += 10;
            }
            else if (carta.getValue() == "ACE")
            {
                if (somaCliente >= 11)
                {
                    somaCliente += 1;
                }
                else
                {
                    somaCliente += 11;
                }
            }
            else
            {
                somaCliente += int.Parse(carta.getValue());
            }
        }

        return somaCliente;
    }

    public async Task VarJogo(Dealer dealer, Cliente cliente,Baralho baralho)
    {
        int somaDealer = 0;
        int somaCliente = 0;

        foreach(var carta in dealer.MaoDealer)
        {
            if(carta.getValue() == "KING" || carta.getValue() == "JACK" || carta.getValue() == "QUEEN")
            {
                somaDealer += 10;
            }
            else if(carta.getValue() == "ACE")
            {
                if(somaDealer >= 11)
                {
                    somaDealer += 1;
                }
                else
                {
                    somaDealer += 11;
                }
            }
            else
            {
                somaDealer += int.Parse(carta.getValue());
            }
        }

        foreach (var carta in cliente.MaoCliente)
        {
            if (carta.getValue() == "KING" || carta.getValue() == "JACK" || carta.getValue() == "QUEEN")
            {
                somaCliente += 10;
            }
            else if (carta.getValue() == "ACE")
            {
                if (somaCliente >= 11)
                {
                    somaCliente += 1;
                }
                else
                {
                    somaCliente += 11;
                }
            }
            else
            {
                somaCliente += int.Parse(carta.getValue());
            }
        }

        while(somaDealer <= 16)
        {
            Carta cartaNovaPuxada = await baralho.PuxarCarta();
            dealer.addCarta(cartaNovaPuxada);
            somaDealer += int.Parse(cartaNovaPuxada.getValue());
        }

        


        if(somaCliente > somaDealer || somaDealer >= 22)
        {
            Console.WriteLine($"Vitoria do jogador soma: {somaCliente}");
        }
        else
        {
            Console.WriteLine($"Vitoria do dealer soma: {somaDealer}");
        }

    }
    public void MostrarMesa(Dealer dealer, Cliente cliente)
    {
        Console.Write("Mao do dealer: ");
        foreach (var carta in dealer.MaoDealer)
        {
            Console.Write($" |---| {carta.getSuit()}-{carta.getValue()}");
        }
        Console.WriteLine("");
        Console.Write("Mao do jogador: ");
        foreach (var carta in cliente.MaoCliente)
        {
            Console.Write($" |---| {carta.getSuit()}-{carta.getValue()}");
        }
    }
}
