using Bet.Modelos.Jogos;


namespace Bet.Modelos;

public class Cliente : Pessoa
{
    private int Id { get; set; }

    private string Senha { get; set; }

    public List<Carta> MaoCliente = new List<Carta>();

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

    public void addCarta(Carta carta)
    {
        MaoCliente.Add(carta);
    }

    public void removeCarta(Carta carta)
    {
        MaoCliente.Remove(carta);
    }
}
