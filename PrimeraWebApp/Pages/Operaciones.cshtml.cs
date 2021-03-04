using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PrimeraWebApp.Pages
{
    public class OperacionesModel : PageModel
    {
        [BindProperty]
        public double Operando1 { get; set; }

        [BindProperty]
        public double Operando2 { get; set; }

        [BindProperty]
        public int Operacion { get; set; }

        [ViewData]
        public double Resultado { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            switch (Operacion)
            {
                case 1:
                    Resultado = Operando1 + Operando2;
                    break;
                case 2:
                    Resultado = Operando1 - Operando2;
                    break;
                case 3:
                    Resultado = Operando1 * Operando2;
                    break;
                case 4:
                    Resultado = Operando1 / Operando2;
                    break;
            }
        }
    }
}