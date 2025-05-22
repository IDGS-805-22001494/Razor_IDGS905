using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace ejercicioRAZOR.Pages
{
    public class CifradoModel : PageModel
    {
        [BindProperty]
        public string Mensaje { get; set; } = "";

        [BindProperty]
        public int Desplazamiento { get; set; }

        [BindProperty]
        public string Accion { get; set; } = "codificar";

        public string Resultado { get; set; } = "";

        private const string Alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public void OnPost()
        {
            if (string.IsNullOrWhiteSpace(Mensaje) || Desplazamiento <= 0)
            {
                Resultado = "Ingrese un mensaje y un valor de desplazamiento válido.";
                return;
            }

            string mensajeMayuscula = Mensaje.ToUpper();
            StringBuilder resultadoBuilder = new();

            foreach (char c in mensajeMayuscula)
            {
                if (c == ' ')
                {
                    resultadoBuilder.Append(' ');
                }
                else if (Alfabeto.Contains(c))
                {
                    int posicionOriginal = Alfabeto.IndexOf(c);
                    int nuevaPosicion = Accion switch
                    {
                        "codificar" => (posicionOriginal + Desplazamiento) % Alfabeto.Length,
                        "decodificar" => (posicionOriginal - Desplazamiento + Alfabeto.Length) % Alfabeto.Length,
                        _ => posicionOriginal
                    };

                    char nuevaLetra = Alfabeto[nuevaPosicion];
                    resultadoBuilder.Append(nuevaLetra);
                }
                else
                {
                    resultadoBuilder.Append(c); 
                }
            }

            Resultado = resultadoBuilder.ToString();
        }
    }
}
