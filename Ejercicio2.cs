using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosC_
{
    internal class Ejercicio2 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Dame un número de Pin de 4 o 6 digitos");
            string? pin = Console.ReadLine();

            if (pin.Length == 4 || pin.Length == 6)
            {
             
                Console.WriteLine($"El pin introducido es valido");
            }
            else
            {
                Console.WriteLine($"El pin introducido es no valido");
            }

        }
    }
}
