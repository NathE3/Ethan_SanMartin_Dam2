using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosC_
{
    class Ejercicio8 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Introduce los datos del primer separados por espacios:");
            string[] datosA = Console.ReadLine().Split(' ');
            int[] primerArray = new int[datosA.Length];
            for (int i = 0; i < datosA.Length; i++)
            {
                try
                {
                    primerArray[i] = int.Parse(datosA[i]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error de formato del array");
                }
            }

            Console.WriteLine("Introduce los datos del segundo array separados por espacios:");
            string[] datosB = Console.ReadLine().Split(' ');
            int[] segundoArray = new int[datosB.Length];
            for (int i = 0; i < datosB.Length; i++)
            {
                try
                {
                    segundoArray[i] = int.Parse(datosB[i]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error de formato del array");
                }
            }

            int[] resultado = DatosDistintos(primerArray, segundoArray);

            foreach (int num in resultado)
            {
                Console.Write(num + " ");
            }
        }

        static int[] DatosDistintos(int[] primerArray, int[] segundoArray)
        {
            HashSet<int> setB = new HashSet<int>(segundoArray);
            List<int> resultado = new List<int>();

            foreach (int num in primerArray)
            {
                if (!setB.Contains(num))
                {
                    resultado.Add(num);
                }
            }

            return resultado.ToArray();
        }
    }
}

