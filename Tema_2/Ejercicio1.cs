using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosC_
{
    internal class Ejercicio1 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Dame una cadena y te dare cuantas vovales tiene: ");
            string? palabra = Console.ReadLine().ToLower();
            string? vocales = "aeiou";
            int? count = 0;

            char[] comparar = palabra.ToCharArray();

            for (int i = 0; i < comparar.Length; i++)
            {
                if (vocales.Contains(comparar[i]))
                {
                 count++;
                }
            }
            Console.WriteLine($"El número de vocales es {count}");
        }
    }
}
