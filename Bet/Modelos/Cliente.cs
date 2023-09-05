namespace Bet.Modelos;

internal class Cliente : Pessoa
{
    public int Id { get; set; }

    public string Senha { get; set; }


    public int GetId()
    {
        return Id;
    }

    public string GetSenha()
    {
        return Senha;
    }
}
