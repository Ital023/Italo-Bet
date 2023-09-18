using Bet.Modelos;
using Bet.Modelos.BancoDeDados;
using Bet.Modelos.Jogos;
using Bet.Modelos.Jogos.BlackJackk;
using System.Net.Http.Json;
using System.Text.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
        BancoDeDados bancoDeDados = new BancoDeDados();

        Cliente cliente = new Cliente(1, "Jogador", 19, "2424");

        bancoDeDados.AdicionarCliente(cliente);

        cliente.Depositar(3000);

        MenuMain.MenuGeneral();

        int escolha = int.Parse(Console.ReadLine());

        if(escolha == 1)
        {
            MenuMain.MenuJogos();
            int escolhaJogos = int.Parse(Console.ReadLine());
            if( escolhaJogos == 1)
            {
                int loop = 0;

                while (loop != 2)
                {
                    MenuMain.Menu(cliente);

                    int opcaoMenu = int.Parse(Console.ReadLine());

                    if (opcaoMenu == 1)
                    {
                        await MenuMain.ExecGameAsync(cliente);
                    }
                    else
                    {
                        loop = 2;
                    }
                }

            }

        }
        else if(escolha == 2)
        {
            MenuMain.MenuADM();
            int escolhaADM = int.Parse(Console.ReadLine());

            if(escolhaADM == 1)
            {
                bancoDeDados.MostrarClientes();
            }
        }













    }

    
}