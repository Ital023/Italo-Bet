using Bet.Modelos.Jogos;
using Bet.Modelos.Jogos.BlackJackk;

namespace Bet.Modelos;

public class Cliente : Jogador
{
    
    private int Cpf { get; set; }
    private string Nome { get; set; }
    private int Idade { get; set; }
    private string Senha { get; set; }
    private double Saldo { get; set; }

    public Cliente(int Cpf, string nome, int idade, string senha)
    {
        Cpf = Cpf;
        Nome = nome;
        Idade = idade;
        Senha = senha;
        Saldo = 0;
    }


    public int GetCpf()
    {
        return Cpf;
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

    public double GetSaldo()
    {
        return Saldo;
    }

    public void Depositar(double valor)
    {
        Saldo += valor;
    }
    public void Sacar(double valor)
    {
        Saldo -= valor;
    }
}

