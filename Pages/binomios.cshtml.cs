using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace ejercicioRAZOR.Pages
{
    public class binomiosModel : PageModel
    {
        [BindProperty] public double a { get; set; }
        [BindProperty] public double b { get; set; }
        [BindProperty] public double x { get; set; }
        [BindProperty] public double y { get; set; }
        [BindProperty] public int n { get; set; }

        public double? Resultado { get; set; }
        public List<string> Pasos { get; set; } = new();

        public void OnPost()
        {
            Resultado = 0;

            for (int k = 0; k <= n; k++)
            {
                double comb = Factorial(n) / (Factorial(k) * Factorial(n - k));
                double ax_pow = Math.Pow(a * x, n - k);
                double by_pow = Math.Pow(b * y, k);
                double term = comb * ax_pow * by_pow;
                Resultado += term;

                Pasos.Add($"Término {k + 1}: C({n},{k}) * (a·x)^{n - k} * (b·y)^{k} = {comb} * {ax_pow} * {by_pow} = {term}");
            }
        }

        private double Factorial(int num)
        {
            double result = 1;
            for (int i = 1; i <= num; i++)
                result *= i;
            return result;
        }
    }
}