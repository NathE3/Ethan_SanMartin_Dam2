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
            Console.WriteLine("Dame una serie de numeros separados por espacio");
            string? numeros = Console.ReadLine();
            string[] numerosArray = numeros.Split(',');
            Dictionary<int,int> arrayNumeros = new Dictionary<int,int>();

            foreach (string numero in numerosArray)
            {
                int.TryParse(numero, out int num);
                arrayNumeros.Add(num,0);
            }

            buscarRepetidosImpares(arrayNumeros);

        }

        public void buscarRepetidosImpares(Dictionary<int,int> lista) {
            int numeroVeces = 0;
            Dictionary<int,int> listaImpares = new Dictionary<int,int>();
            foreach (KeyValuePair<int, int> numero in lista)
            {
                if (!lista.ContainsKey(numero.Key))
                {
                    lista.Add(numero.Key, 1);

                }
                else if (lista.ContainsKey(numero.Key)) {
                    lista.Add((numero.Value + 1));
                }
            
            }

            foreach (KeyValuePair<int, int> numero in lista) {
                {
                    if (numero.Value % 2 == 1)
                    {
                        listaImpares.Add(numero.Key, numero.Value);

                    }
                }
                Console.WriteLine($"Tus números impares es {listaImpares}");

        }
        
        }
    }
}