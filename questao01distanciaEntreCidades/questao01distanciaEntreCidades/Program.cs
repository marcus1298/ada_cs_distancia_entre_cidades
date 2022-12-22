using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;


namespace ConsoleApp1
{
    internal class Class
    {
        static void Main()
        {
            var Matriz = LeitorCsv("matriz.txt.txt");
            int tamanhoM = (int)Math.Sqrt(Matriz.Count());

            int[,] cidades = new int[tamanhoM, tamanhoM];

            int m = 0;
            for (int i = 0; i < tamanhoM; i++)
            {

                for (int j = 0; j < tamanhoM; j++)
                {
                    int.TryParse(Matriz[m], out cidades[i, j]);
                    m++;
                }
            }
            var Percurso = LeitorCsv("caminho.txt.txt");
            int sum = 0;
            for (int i = 0; i < Percurso.Count() - 1; i++)
            {
                sum = sum + cidades[Convert.ToInt32(Percurso[i]) - 1, Convert.ToInt32(Percurso[(i + 1)]) - 1];
            }
            Console.WriteLine($"{sum} km");

        }
        public static string ConfigFile(string nomeArquivo)
        {
            var caminhoDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var caminhoArquivo = Path.Combine(caminhoDesktop, nomeArquivo);
            return caminhoArquivo;
        }

        public static List<string> LeitorCsv(string nomeArquivo)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            var caminhoMatriz = ConfigFile(nomeArquivo);
            using var reader = new StreamReader(caminhoMatriz);
            using var csv = new CsvParser(reader, config);

            var items = new List<string>();

            while (csv.Read())
            {
                foreach (var item in csv.Record)
                {
                    items.Add(item);
                }
            }

            return items;
        }
    }
}