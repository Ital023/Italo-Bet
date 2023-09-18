using Bet.Modelos.Jogos.BlackJackk;
using Bet.Modelos.Jogos;

namespace Bet.Modelos;

public class MenuMain
{
    public static void MenuGeneral()
    {
        Console.WriteLine("$$$---Italo BET---$$$");
        Console.WriteLine("");

        Console.WriteLine("1-Acessar aos jogos");
        Console.WriteLine("2-Ir a area ADM");
        Console.WriteLine("---------------------");


        Console.Write("Insira a opcao: ");
    }

    public static void MenuADM()
    {
        Console.Clear();
        Console.WriteLine("$$$---Italo BET---$$$");
        Console.WriteLine("");

        Console.WriteLine("1-Acessar aos clientes");
        Console.WriteLine("---------------------");


        Console.Write("Insira a opcao: ");
    }

    public static void MenuJogos()
    {
        Console.Clear();
        Console.WriteLine("$$$---JOGOS---$$$");
        Console.WriteLine("");

        Console.WriteLine("1-BlackJack");
        Console.WriteLine("---------------------");
        Console.Write("Insira a opcao: ");

    }

    public static void Menu(Cliente cliente)
    {
        Console.Clear();
        Console.WriteLine("$$-BLACKJACK-$$");
        Console.WriteLine("");
        Console.WriteLine($"Bem vindo {cliente.GetNome()}");
        Console.WriteLine($"Seu saldo: {cliente.GetSaldo()}");
        Console.WriteLine("");
        Console.WriteLine("-----------------------");
        Console.WriteLine("1-Iniciar Jogo");
        Console.WriteLine("0-Sair");
        Console.WriteLine("-----------------------");
    }

    public static async Task ExecGameAsync(Cliente cliente)
    {
        Console.Clear();
        BlackJack blackJack = new BlackJack();
        Dealer dealer = new Dealer("Daniel");
        Baralho baralho = new Baralho();


        int tryValor = 1;
        int valorAposta = 0;

        while (tryValor != 0)
        {
            await Console.Out.WriteLineAsync("Insira o valor que deseja apostar: ");
            valorAposta = int.Parse(Console.ReadLine());

            if (cliente.GetSaldo() < valorAposta)
            {
                await Console.Out.WriteLineAsync("Valor invalido,Insira novamente");
            }
            else
            {
                tryValor = 0;
            }
            Console.Clear();
        }

        cliente.Sacar(valorAposta);

        await baralho.CriarBaralho();


        await blackJack.CriarMesa(dealer, cliente, baralho);

        blackJack.MostrarMesa(dealer, cliente);
        await Console.Out.WriteLineAsync("");

        await Console.Out.WriteLineAsync("Clique para continuar");


        Console.ReadKey();

        int pushCard = 1;

        while (pushCard != 2)
        {

            if (cliente.SomaDasCartas < 21)
            {
                await Console.Out.WriteLineAsync("");
                await Console.Out.WriteLineAsync("1-Sim 2-Não");
                await Console.Out.WriteAsync("Deseja puxar mais uma carta: ");
                int opcBj = int.Parse(Console.ReadLine());
                if (opcBj == 1)
                {
                    cliente.addCarta(await baralho.PuxarCarta());
                    Console.Clear();
                    blackJack.MostrarMesa(dealer, cliente);
                }
                else
                {
                    pushCard = 2;
                }
            }
            else
            {
                await Console.Out.WriteLineAsync("Voce estorou");
                pushCard = 2;
            }


        }

        Console.Clear();


        await Console.Out.WriteLineAsync("");


        int retornoJogo = await blackJack.VarJogo(dealer, cliente, baralho, blackJack);

        await Console.Out.WriteLineAsync("Clique para continuar");

        if (retornoJogo == 1)
        {
            int valorDobrado = valorAposta * 2;
            cliente.Depositar(valorDobrado);
        }


        Console.ReadKey();

        Console.Clear();

        await Console.Out.WriteLineAsync("Clique para sair");


        Console.ReadKey();
    }
}
