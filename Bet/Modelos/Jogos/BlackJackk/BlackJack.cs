using Bet.Modelos.Jogos.BlackJackk;
using Bet.Modelos.Jogos;

namespace Bet.Modelos.Jogos;

public class BlackJack
{
    public async Task CriarMesa(Dealer dealer, Cliente cliente, Baralho baralho)
    {
        dealer.Mao.Clear();
        cliente.Mao.Clear();

        if (dealer.Mao.Count <= 0 || cliente.Mao.Count <= 0)
        {
            
                Carta cartaCliente = await baralho.PuxarCarta();
                cliente.addCarta(cartaCliente);

                Carta cartaDealer = await baralho.PuxarCarta();
                dealer.addCarta(cartaDealer);

                cartaCliente = await baralho.PuxarCarta();
                cliente.addCarta(cartaCliente);
        }
    }



    public async Task<int> VarJogo(Dealer dealer, Cliente cliente, Baralho baralho,BlackJack blackJack)
    {
        int somaDealer = 0;
        int somaCliente = 0;

        blackJack.MostrarMesa(dealer, cliente);

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

            Console.Clear();

            blackJack.MostrarMesa(dealer, cliente);

        }
        if ((cliente.SomaDasCartas > dealer.SomaDasCartas && !(cliente.SomaDasCartas >= 22)) || dealer.SomaDasCartas > 21)
        {
            Console.WriteLine($"Vitoria do jogador soma: {cliente.SomaDasCartas}");
            return 1;
        }
        else if (cliente.SomaDasCartas == dealer.SomaDasCartas)
        {
            await Console.Out.WriteLineAsync("Empate");
            return 0;
        }
        else
        {
            Console.WriteLine($"Vitoria do dealer soma: {dealer.SomaDasCartas}");
            return 2;
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