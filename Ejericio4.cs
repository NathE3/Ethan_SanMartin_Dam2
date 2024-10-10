using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EjerciciosC_
{
    internal class Ejercicio4 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Dame una serie de numeros separados por ,");
            string? numeros = Console.ReadLine();
            string[] numerosArray = numeros.Split(',');
            Dictionary<int, int> arrayNumeros = new Dictionary<int, int>();

            foreach (string numero in numerosArray)
            {
                int.TryParse(numero, out int num);

                if (!arrayNumeros.ContainsKey(num))
                {
                    arrayNumeros.Add(num, 1);
                }
                else
                {
                    arrayNumeros[num]++;
                }

            }

            Dictionary<int, int> listaImpares = buscarRepetidosImpares(arrayNumeros);
            mostrarImpares(listaImpares);

        }

        public Dictionary<int, int> buscarRepetidosImpares(Dictionary<int, int> lista)
        {

            Dictionary<int, int> listaImpares = new Dictionary<int, int>();

            foreach (KeyValuePair<int, int> numero in lista)
            {
                if (numero.Value % 2 != 0)
                {
                    listaImpares.Add(numero.Key, numero.Value);
                }
            }
            return listaImpares;


        }


        public void mostrarImpares(Dictionary<int, int> listaImpares)
        {

            Console.WriteLine("Tus números repetidos son:");
            foreach (KeyValuePair<int, int> impar in listaImpares)
            {
                Console.WriteLine($"Número: {impar.Key}, Veces: {impar.Value}");
            }

        }
    }
}