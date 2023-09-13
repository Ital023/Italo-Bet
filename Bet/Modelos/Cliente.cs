using Bet.Modelos.Jogos;
using Bet.Modelos.Jogos.BlackJackk;

namespace Bet.Modelos;

public class Cliente : Jogador
{
    
    private int Id { get; set; }
    private string Nome { get; set; }
    private int Idade { get; set; }
    private string Senha { get; set; }

    public Cliente(int id, string nome, int idade, string senha)
    {
        Id = id;
        Nome = nome;
        Idade = idade;
        Senha = senha;
    }


    public int GetId()
    {
        return Id;
    }

    public string GetSenha()
    {
        return Senha;
    }

    public int GetIdade()
    {
        return Idade;
    }

    public string GetNome()
    {
        return Nome;
    }
}

