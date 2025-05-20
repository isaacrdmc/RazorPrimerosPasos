using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages
{
    public class ArregloEstadisticoModel : PageModel
    {
        // Creamos las variables que necesitaremos:
        [BindProperty]
        public int[] Numeros { get; set; } = new int[20];
        [BindProperty]
        public int[] NumerosOrdenados { get; set; } = new int[20];
        [BindProperty]
        public int Suma { get; set; }
        [BindProperty]
        public double Promedio { get; set; }
        [BindProperty]
        public string Moda { get; set; }
        [BindProperty]
        public string Mediana { get; set; }

        public void OnGet()
        {
            GenerarNumerosAleatorios();
            CalcularEstadisticas();
        }

        //public IActionResult OnPost()
        //{
                        
        //}


        // ? Creamos el metodo para poder generar los números aleatorios
        private void GenerarNumerosAleatorios()
        {
            Random random = new Random();
            Numeros = Enumerable.Range(0, 20)
                .Select(_ => random.Next(0, 101))
                .ToArray();
        }

        // ? Ahora creamos el metodo para poder realizar los cálculso estad+ísticos:
        private void CalcularEstadisticas()
        {
            // Primero ordenamos el arreglo:
            NumerosOrdenados = Numeros.OrderBy(n => n).ToArray();

            // Ahora calculamos la suma:
            Suma = Numeros.Sum();

            // Ahora calculamos el promedio:
            Promedio = Numeros.Average();

            // Ahora calculamos la moda:
            var grupos = Numeros.GroupBy(n => n)
                .OrderByDescending(g => g.Count())
                .ToList();

            int maxCount = grupos.First().Count();
            var modas = grupos.Where(g => g.Count() == maxCount)
                             .Select(g => g.Key.ToString())
                             .ToList();

            Moda = string.Join(", ", modas);


            // Ahora calculamos la mediana:
            int mitad = NumerosOrdenados.Length / 2;
            if (NumerosOrdenados.Length % 2 == 0)
            {
                double mediana = (NumerosOrdenados[mitad - 1] + NumerosOrdenados[mitad]) / 2.0;
                Mediana = $"({NumerosOrdenados[mitad - 1]} + {NumerosOrdenados[mitad]})/2 = {mediana}";
            }
            else
            {
                Mediana = NumerosOrdenados[mitad].ToString();
            }
        }
    }
}
