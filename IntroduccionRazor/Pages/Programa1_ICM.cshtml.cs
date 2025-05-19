using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages
{
    public class Programa1_ICMModel : PageModel
    {
        // Primero definimos las variables cuyo valor sera el ingresado por el usuario
        [BindProperty]
        public string altura { get; set; } = "";
        
        [BindProperty]
        public string peso { get; set; } = "";



        public double imc = 0;
        public string imagenMostrar { get; set; } = "";

        //
        public void OnGet() {}


        // Realizamos el cálculo
        public void OnPost()
        {

            // Primero validamos que los campos no esten vacios:
            if (string.IsNullOrWhiteSpace(altura) || string.IsNullOrWhiteSpace(peso))
            {
                ModelState.AddModelError("", "Ingresa ambos valores dentro de los cmapos que se indican");
                return;
            }

            // Ahora validamos que lso valores ingresados sean positivos:
            if (!double.TryParse(altura, out double alturaUsuario) || !double.TryParse(peso, out double pesoUsuario))
            {
                ModelState.AddModelError("", "Los valores ingresados no son válidos.");
                return;
            }


            // Recibimos los datos del formulario y los transormos a enteros
            //double alturaUsuario = Convert.ToDouble(altura);
            //double pesoUsuario = Convert.ToDouble(peso);









            // Hora hacemos el cálculo
            double alturaMetros = alturaUsuario / 100.0;
            imc = pesoUsuario / (alturaMetros * alturaMetros);






            // Realizamos la comparación para mostrar el tipo de imégne acorde
            if (imc < 18.5) {
                imagenMostrar = "images/BajoPeso.png";
            } else if (imc > 18.5 && imc < 24.9)
            {
                imagenMostrar = "images/PesoNormal.png";

            } else if (imc > 25.0 && imc < 29.9)
            {
                imagenMostrar = "images/SobrePeso.png";
            } else if (imc > 30.0 && imc < 34.9)
            {
                imagenMostrar = "images/ObesidadUno.png";
            } else if (imc > 35.0 && imc < 39.9)
            {
                imagenMostrar = "images/ObesidadDos.png";
            } else
            {
                imagenMostrar = "images/ObesidadTres.png";
            }

            // No limpiamos los campos de entrada de texto
        }
    }
}
