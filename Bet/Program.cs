using Bet.Modelos;
using Bet.Modelos.Jogos;
using Bet.Modelos.Jogos.BlackJackk;
using System.Net.Http.Json;
using System.Text.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
        /*Baralho baralho = new Baralho();
        Dealer dealer = new Dealer("Anony");
        await baralho.CriarBaralho();


         int i = 1;

         while(i != 0)
         {
             menu();
             await Console.Out.WriteAsync("Insira a opc: ");
             int opcNum = int.Parse(Console.ReadLine());

             switch (opcNum)
             {
                 case 1:
                     Console.Clear();
                     int j = 1;
                     while(j != 0)
                     {
                         await Console.Out.WriteLineAsync("Deseja puxar uma carta : 1- sim 2- nao");
                         int opcNumCard = int.Parse(Console.ReadLine());

                         if (opcNumCard == 1)
                         {
                             Carta carta = await baralho.PuxarCarta();
                             dealer.addCarta(carta);
                         }
                         else
                         {
                             j = 0;

                         }
                     }



                     Console.ReadKey();
                     break;
                 case 2:
                     Console.Clear();
                     baralho.mostrarBaralho();
                     dealer.mostrarMao();
                     Console.ReadKey();
                     break;
                 case 4:
                     i = 0;
                     break;
             }
         } 
        */


        BlackJack blackJack = new BlackJack();
        Dealer dealer = new Dealer("Daniel");
        Cliente cliente = new Cliente("Cadu", "2023", 19, 0231);
        Baralho baralho = new Baralho();
        await baralho.CriarBaralho();


        await blackJack.CriarMesa(dealer,cliente,baralho);

        blackJack.MostrarMesa(dealer,cliente);
        await Console.Out.WriteLineAsync("");

        int pushCard = 1;

        while( pushCard != 2 ) 
        {
            await Console.Out.WriteLineAsync("1-Sim 2-Não");
            await Console.Out.WriteAsync("Deseja puxar mais uma carta: ");
            int opcBj = int.Parse(Console.ReadLine());

            if(opcBj == 1 )
            {
                if(blackJack.ValorCartaJogador(cliente) < 21)
                {
                    cliente.addCarta(await baralho.PuxarCarta());
                }
                else
                {
                    await Console.Out.WriteLineAsync("Voce estorou");
                }
            }
            else
            {
                pushCard = 2;
            }
        }



        await Console.Out.WriteLineAsync("");

        await blackJack.VarJogo(dealer,cliente,baralho);

        await Console.Out.WriteLineAsync("");

        await Console.Out.WriteLineAsync("Depois da distribuição");

        blackJack.MostrarMesa(dealer, cliente);






    }

    public static void menu()
    {
        Console.Clear();
        Console.WriteLine("-----------------------");
        Console.WriteLine("1-Iniciar Jogo");
        Console.WriteLine("2-Mostrar Baralho");
        Console.WriteLine("3-Criar Mesa");
        Console.WriteLine("-----------------------");
    }
}