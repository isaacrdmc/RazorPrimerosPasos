using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages {
    public class SumaNumerosModelModel : PageModel {
        // Definimos los atributos del modelo
        [BindProperty]
        public string num1 { get; set; } = "";
        [BindProperty]
        public string num2 { get; set; } = "";
        public int suma = 0;

        //
        public void OnGet() {
        }

        // Metodo para trabajr con post:
        public void OnPost() {
            // Recibe los datos del formulario
            int numero1 = Convert.ToInt32(num1);
            int numero2 = Convert.ToInt32(num2);

            suma = numero1 + numero2;

            // Limpiamos los campos
            ModelState.Clear();
        }
    }
}
