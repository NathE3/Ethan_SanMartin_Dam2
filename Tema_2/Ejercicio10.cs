using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosC_
{
    class Ejercicio10 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Introduce un número decimal:");
            int num = int.Parse(Console.ReadLine());

            if (num < 0)
            {
                Console.WriteLine("El número no puede ser negativo");
            }
            else
            {
                int resultado = ContarBits(num);
                Console.WriteLine("Número de bits que son iguales a 1: " + resultado);
            }
        }

        static int ContarBits(int num)
        {
            string binario = Convert.ToString(num, 2);
            int contador = 0;

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] == '1')
                {
                    contador++;
                }
            }

            return contador;
        }
     }
}
