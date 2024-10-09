using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosC_
{
    class Ejercicio5 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Dame una serie de numeros separados por ,");
            string? numeros = Console.ReadLine();
            string[] numerosArray = numeros.Split(',');
            List<int> arrayNumeros = new List<int>();

            foreach (string numero in numerosArray)
            {
                int.TryParse(numero, out int num);

                if (!arrayNumeros.Contains(num))
                {
                    arrayNumeros.Add(num);
                }

            }

            mostrarImpares(arrayNumeros);

        }
        public void mostrarImpares(List<int> listaLimpio)
        {

            Console.WriteLine("Tus números repetidos sin repetidos es:");
            foreach (int numero in listaLimpio)
            {
                Console.WriteLine($"Tus número son: {numero}");
            }

        }
    }
}
    

