using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ejercicioRAZOR.Pages
{
    public class IMCModel : PageModel
    {
        [BindProperty]
        public double Peso { get; set; }

        [BindProperty]
        public double Altura { get; set; }

        public double ResultadoIMC { get; set; }

        public string Clasificacion { get; set; } = "";

        public string ImagenRecomendacion { get; set; } = "";

        public void OnPost()
        {
            ResultadoIMC = Peso / (Altura * Altura);

            if (ResultadoIMC < 18)
            {
                Clasificacion = "Peso Bajo";
                ImagenRecomendacion = "/images/peso_bajo.png";
            }
            else if (ResultadoIMC >= 18 && ResultadoIMC < 25)
            {
                Clasificacion = "Peso Normal";
                ImagenRecomendacion = "/images/peso_normal.png";
            }
            else if (ResultadoIMC >= 25 && ResultadoIMC < 27)
            {
                Clasificacion = "Sobrepeso";
                ImagenRecomendacion = "/images/sobrepeso.png";
            }
            else if (ResultadoIMC >= 27 && ResultadoIMC < 30)
            {
                Clasificacion = "Obesidad grado I";
                ImagenRecomendacion = "/images/obesidad1.png";
            }
            else if (ResultadoIMC >= 30 && ResultadoIMC < 40)
            {
                Clasificacion = "Obesidad grado II";
                ImagenRecomendacion = "/images/obesidad2.png";
            }
            else
            {
                Clasificacion = "Obesidad grado III";
                ImagenRecomendacion = "/images/obesidad3.png";
            }
        }
    }
}
