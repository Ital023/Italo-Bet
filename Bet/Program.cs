﻿using Bet.Modelos;
using Bet.Modelos.Jogos;
using System.Net.Http.Json;
using System.Text.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Baralho baralho = new Baralho();
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
                            await baralho.PuxarCarta();

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
                    Console.ReadKey();
                    break;
                case 3:
                    i = 0;
                    break;
            }
        }
        

        
        

        
    }

    public static void menu()
    {
        Console.Clear();
        Console.WriteLine("-----------------------");
        Console.WriteLine("1-Iniciar Jogo");
        Console.WriteLine("2-Mostrar Baralho");
        Console.WriteLine("-----------------------");
    }
}