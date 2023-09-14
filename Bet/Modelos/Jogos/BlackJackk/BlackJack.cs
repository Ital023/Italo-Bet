using Bet.Modelos.Jogos.BlackJackk;
using Bet.Modelos.Jogos;

namespace Bet.Modelos.Jogos;

public class BlackJack
{
    public async Task CriarMesa(Dealer dealer, Cliente cliente, Baralho baralho)
    {
        if (dealer.Mao.Count <= 0 || cliente.Mao.Count <= 0)
        {
            for (int i = 0; i < 2; i++)
            {
                Carta cartaCliente = await baralho.PuxarCarta();
                cliente.addCarta(cartaCliente);

                Carta cartaDealer = await baralho.PuxarCarta();
                dealer.addCarta(cartaDealer);
            }
        }
    }

    

    public async Task VarJogo(Dealer dealer, Cliente cliente, Baralho baralho)
    {
        int somaDealer = 0;
        int somaCliente = 0;

        dealer.MostrarMao();

        cliente.MostrarMao();

        while (dealer.SomaDasCartas <= 16 && cliente.SomaDasCartas <= 21)
        {
            Carta cartaNovaPuxada = await baralho.PuxarCarta();
            dealer.addCarta(cartaNovaPuxada);

            if (cartaNovaPuxada.getValue() == "JACK" || cartaNovaPuxada.getValue() == "QUEEN" || cartaNovaPuxada.getValue() == "KING")
            {
                dealer.SomaDasCartas += 10;
            }
            else if (cartaNovaPuxada.getValue() == "ACE")
            {
                if (dealer.SomaDasCartas <= 10)
                {
                    dealer.SomaDasCartas += 11;
                }
                else
                {
                    dealer.SomaDasCartas += 1;
                }
            }
            else
            {
                dealer.SomaDasCartas += int.Parse(cartaNovaPuxada.getValue());
            }
        }
        if ((cliente.SomaDasCartas > dealer.SomaDasCartas && !(cliente.SomaDasCartas >= 22)) || dealer.SomaDasCartas > 21)
        {
            Console.WriteLine($"Vitoria do jogador soma: {cliente.SomaDasCartas}");
        }
        else if(cliente.SomaDasCartas == dealer.SomaDasCartas)
        {
            await Console.Out.WriteLineAsync("Empate");
        }
        else
        {
            Console.WriteLine($"Vitoria do dealer soma: {dealer.SomaDasCartas}");
        }
    }
         

    public void MostrarMesa(Dealer dealer, Cliente cliente)
    {
        Console.Write("Mao do dealer: ");
        dealer.MostrarMao();
        Console.WriteLine("");
        Console.Write("Mao do jogador: ");
        cliente.MostrarMao();
    }
}