using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ejercicioRAZOR.Pages
{
    public class EstadisticasModel : PageModel
    {
        public int[] NumerosAleatorios { get; set; } = new int[0];
        public int[] NumerosOrdenados { get; set; } = new int[0];
        public int Suma { get; set; }
        public double Promedio { get; set; }
        public List<int> Moda { get; set; } = new();
        public double Mediana { get; set; }

        public void OnPost()
        {
            Random rnd = new Random();
            NumerosAleatorios = new int[20];


            for (int k = 0; k < NumerosAleatorios.Length; k++)
            {
                NumerosAleatorios[k] = rnd.Next(0, 101);
            }

            int index = 0;
            Suma = 0;
            while (index < NumerosAleatorios.Length)
            {
                Suma += NumerosAleatorios[index];
                index++;
            }

            Promedio = (double)Suma / NumerosAleatorios.Length;

            NumerosOrdenados = (int[])NumerosAleatorios.Clone();
            Array.Sort(NumerosOrdenados);

            int mid = NumerosOrdenados.Length / 2;
            if (NumerosOrdenados.Length % 2 == 0)
            {
                Mediana = (NumerosOrdenados[mid - 1] + NumerosOrdenados[mid]) / 2.0;
            }
            else
            {
                Mediana = NumerosOrdenados[mid];
            }

            Dictionary<int, int> frecuencia = new();
            int i = 0;
            do
            {
                int num = NumerosAleatorios[i];
                if (frecuencia.ContainsKey(num))
                    frecuencia[num]++;
                else
                    frecuencia[num] = 1;
                i++;
            } while (i < NumerosAleatorios.Length);

            int maxFrecuencia = frecuencia.Values.Max();
            Moda = frecuencia
                .Where(kvp => kvp.Value == maxFrecuencia && maxFrecuencia > 1)
                .Select(kvp => kvp.Key)
                .OrderBy(n => n)
                .ToList();

            if (Moda.Count == 0)
                Moda.Add(-1); 
        }
    }
}
