namespace Bet.Modelos.Jogos.BlackJackk;

public class Dealer
{
    public string Nome { get; set; }

    public List<Carta> MaoDealer = new List<Carta>();

    public Dealer(string nome)
    {
        Nome = nome;
    }

    public void addCarta(Carta carta)
    {
        MaoDealer.Add(carta);
    }

    public void removeCarta(Carta carta)
    {
        MaoDealer.Remove(carta);
    }

    public string getNome()
    {
        return Nome;
    }

    public void mostrarMao()
    {
        
        
            foreach (var carta in MaoDealer)
            {
                Console.WriteLine($"--{carta.getSuit()}--{carta.getValue()}--");
            }
  
        
    }
}
