using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages
{
    public class CifradoCesarModel : PageModel
    {

        // Declaramos las variables para el programa
        [BindProperty]
        public string TextoOriginal { get; set; }
        [BindProperty]
        public int Desplazamiento { get; set; }
        public string TextoCifrado { get; set; }

        // 
        public void OnPost()
        {
            TextoCifrado = CifrarCesar(TextoOriginal, Desplazamiento);
        }

        // 
        private string CifrarCesar(string texto, int desplazamiento)
        {
            string resultado = "";
            foreach (char c in texto)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    char cifrado = (char)((((c - baseChar) + desplazamiento) % 26 + 26) % 26 + baseChar);
                    resultado += cifrado;
                } else
                {
                    resultado += c;
                }
            }
            return resultado;

        }


        // 
        public void OnGet()
        {
        }
    }
}
