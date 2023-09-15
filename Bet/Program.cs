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
        int loop = 0;

        while (loop != 2)
        {
            menu();

            int opcaoMenu = int.Parse(Console.ReadLine());

            if (opcaoMenu == 1)
            {
                Console.Clear();
                BlackJack blackJack = new BlackJack();
                Dealer dealer = new Dealer("Daniel");
                Cliente cliente = new Cliente(1, "Cadu", 19, "2424");
                Baralho baralho = new Baralho();
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


                await blackJack.VarJogo(dealer, cliente, baralho,blackJack);

                await Console.Out.WriteLineAsync("Clique para continuar");


                Console.ReadKey();

                Console.Clear();

                await Console.Out.WriteLineAsync("Clique para sair");


                Console.ReadKey();

            }
            else
            {
                loop = 2;
            }
        }

        






    }

    public static void menu()
    {
        Console.Clear();
        Console.WriteLine("-----------------------");
        Console.WriteLine("1-Iniciar Jogo");
        Console.WriteLine("-----------------------");
    }
}