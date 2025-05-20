using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace IntroduccionRazor.Pages
{
    public class ComprobacionCalculoModel : PageModel
    {
        [BindProperty]
        public double A { get; set; } = 1;

        [BindProperty]
        public double X { get; set; } = 1;

        [BindProperty]
        public double B { get; set; } = 1;

        [BindProperty]
        public double Y { get; set; } = 1;

        [BindProperty]
        public int N { get; set; } = 2;

        public double? Resultado { get; set; }
        public string Desarrollo { get; set; }
        public string Error { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            try
            {
                if (N < 0)
                {
                    Error = "El valor de 'n' debe ser un entero no negativo";
                    return;
                }

                double resultado = 0;
                string desarrollo = "";

                for (int k = 0; k <= N; k++)
                {
                    long coeficiente = Factorial(N) / (Factorial(k) * Factorial(N - k));
                    double termino = coeficiente * Math.Pow(A * X, N - k) * Math.Pow(B * Y, k);
                    resultado += termino;

                    if (k > 0) desarrollo += " + ";
                    desarrollo += $"{coeficiente}·({A * X}<sup>{N - k}</sup>)·({B * Y}<sup>{k}</sup>)";
                }

                Resultado = resultado;
                Desarrollo = desarrollo;
            }
            catch (Exception ex)
            {
                Error = $"Error en el cálculo: {ex.Message}";
            }
        }

        private long Factorial(int num)
        {
            if (num <= 1) return 1;
            long result = 1;
            for (int i = 2; i <= num; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}