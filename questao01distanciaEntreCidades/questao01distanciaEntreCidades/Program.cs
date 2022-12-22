/*  Entradas
5

15 30 05 12
10 17 28
03 11
80

1, 2, 3, 2, 5, 1, 4
*/
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Class
    {
        static void Main()
        {
            Console.WriteLine("Escreva o tamanho da matriz:");
            int.TryParse(Console.ReadLine(), out int n);
            int[,] cidades = new int[n, n];
            Console.WriteLine("Escreva a matriz da diagonal principal para baixo:");
            for (int i = 0; i < n - 1; i++)
            {

                string a = Console.ReadLine();


                string[] splitInputs = a.Split(' ', ',');
                int m = 0;
                for (int j = i; j < n; j++)
                {
                    if (i == j)
                    {
                        int.TryParse("0", out cidades[i, j]);
                        int.TryParse("0", out cidades[j, i]);
                    }
                    else
                    {
                        int.TryParse(splitInputs[m], out cidades[i, j]);
                        int.TryParse(splitInputs[m], out cidades[j, i]);
                        m++;
                    }
                }
            }
            Console.WriteLine("Escreva um caminho:");
            string caminho;
            caminho = Console.ReadLine();
            caminho = caminho.Trim();
            string[] splitCaminho = caminho.Split(',');
            int[] array = splitCaminho.Select(lnq => int.Parse(lnq)).ToArray();
            int sum = 0;
            for (int i = 0; i < splitCaminho.Length - 1; i++)
            {
                sum = sum + cidades[Convert.ToInt32(splitCaminho[i]) - 1, Convert.ToInt32(array[(i + 1)]) - 1];
            }
            Console.WriteLine($"{sum} km");
        }
    }
}