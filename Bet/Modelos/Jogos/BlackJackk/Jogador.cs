namespace Bet.Modelos.Jogos.BlackJackk;

public class Jogador
{
    public List<Carta> Mao = new List<Carta>();

    public int SomaDasCartas { get; set; }

    public void addCarta(Carta carta)
    {
        Mao.Add(carta);
    }

    public void removeCarta(Carta carta)
    {
        Mao.Remove(carta);
    }

    public void MostrarMao()
    {
        SomaDasCartas = 0;
        foreach(Carta carta in Mao)
        {
            if(carta.getValue() == "JACK" ||  carta.getValue() == "QUEEN" || carta.getValue() == "KING")
            {
                SomaDasCartas += 10;
            }
            else if(carta.getValue() == "ACE")
            {
                if(SomaDasCartas <= 10)
                {
                    SomaDasCartas += 11;
                }
                else
                {
                    SomaDasCartas += 1;
                }
            }
            else
            {
                SomaDasCartas += int.Parse(carta.getValue());
            }

            Console.Write($"--{carta.getSuit()}--{carta.getValue()}--||");
        }

        Console.WriteLine($"$$---$$ Soma das cartas: {SomaDasCartas}");

    }

}
