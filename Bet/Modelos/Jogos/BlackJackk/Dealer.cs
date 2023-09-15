namespace Bet.Modelos.Jogos.BlackJackk;

public class Dealer : Jogador
{
    public string Nome { get; set; }

    public Dealer(string nome)
    {
        Nome = nome;
    }

    public string getNome()
    {
        return Nome;
    }
        
}



