/*
15 30 05 12
10 17 28
03 11
80
1, 2, 3, 2, 5, 1, 4
*/
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Collections.Generic;
using System.Security;
using System.Data.Common;

namespace ConsoleApp1
{
    internal class Class
    {
        static void Main()
        {
            string path1 = @"C:\Users\marco\Desktop\matriz.txt";
            string path2 = @"C:\Users\marco\Desktop\caminho.txt";
            StreamReader leitor = new StreamReader(path1);
            string matriz = leitor.ReadToEnd();
            matriz = matriz.Replace("\r", "");
            Console.WriteLine(matriz);
            StreamReader leitor1 = new StreamReader(path2);
            string percurso = leitor1.ReadToEnd();
            Console.WriteLine(percurso);
            matriz = matriz.Trim();
            percurso = percurso.Trim();
            string[] matrizNew = matriz.Split(',', '\n');
            string[] percursoNew = percurso.Split(',');
            double tamanho = 0;
            foreach (string element in matrizNew)
            {
                tamanho++;
            }
            tamanho = Math.Sqrt(tamanho);
            int n = (int)tamanho;
            int[,] cidades = new int[n, n];
            string[] splitInputs = matrizNew;
            int m = 0;
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    int.TryParse(splitInputs[m], out cidades[i, j]);
                    m++;
                }
            }
            int[] array = percursoNew.Select(lnq => int.Parse(lnq)).ToArray();
            int sum = 0;
            Console.WriteLine(cidades);
            Console.WriteLine(percursoNew);
            for (int i = 0; i < percursoNew.Length - 1; i++)
            {
                sum = sum + cidades[Convert.ToInt32(percursoNew[i]) - 1, Convert.ToInt32(array[(i + 1)]) - 1];
            }
            Console.WriteLine($"{sum} km");
        }
    }
}