namespace Bet.Modelos.BancoDeDados;

public class BancoDeDados
{
    public List<Cliente> clientes = new List<Cliente>();

    public static void RegistrarCliente(BancoDeDados bancoDeDados)
    {
        Console.Write("Insira o seu nome: ");
        string nome = Console.ReadLine();

        Console.Write("Insira o cpf: ");
        int cpf = int.Parse(Console.ReadLine());

        Console.Write("Insira a idade: ");
        int idade = int.Parse(Console.ReadLine());

        Console.Write("Insira a senha: ");
        string senha = Console.ReadLine();

        Cliente cliente = new(cpf, nome, idade, senha);

        bancoDeDados.AdicionarCliente(cliente);
    }

    public void AdicionarCliente(Cliente cliente)
    {
        clientes.Add(cliente);
    }

    public void MostrarClientes()
    {
        foreach (Cliente cliente in clientes)
        {
            Console.WriteLine($"Nome: {cliente.GetNome()} | Cpf: {cliente.GetCpf()} | Idade: {cliente.GetIdade()} | Saldo: {cliente.GetSaldo()}");
        }
    }
}
