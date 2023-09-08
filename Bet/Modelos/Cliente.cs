using Bet.Modelos.Jogos;


namespace Bet.Modelos;

internal class Cliente : Pessoa
{
    private int Id { get; set; }

    private string Senha { get; set; }

    public List<Carta> cartas { get; set; }

    public Cliente (string nome,string senha,int idade,int cpf)
    {
        SetNome(nome);
        SetIdade (idade);
        SetCpf (cpf);
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
}
