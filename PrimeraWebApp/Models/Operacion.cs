using System;
 
namespace PrimeraWebApp.Models {
    public class Operacion {        
        public decimal Operando1 {get; set;}        
        public decimal Operando2 {get; set;}        
        public int Operador {get; set;}
 
        public decimal Ejecutar() {
            decimal Resultado = 0;
            if (Operador == 1)
                Resultado = Operando1 + Operando2;
            else if (Operador == 2)
                Resultado = Operando1 - Operando2;
            else if (Operador == 3)
                Resultado = Operando1 * Operando2;
            else if (Operador == 4)
                Resultado = Operando1 / Operando2;            
            return Resultado;
        }
    }
}