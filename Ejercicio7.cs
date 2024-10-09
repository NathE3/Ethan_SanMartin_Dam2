using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EjerciciosC_
{
    class Ejercicio7 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Dame un array separado por comas: ");
            string? numeros = Console.ReadLine();
            string[] arraySt =  numeros.Split(',');
            int[] arrayIn = new int[arraySt.Length]; 

            for (int i = 0; i < arraySt.Length; i++) 
            {
                try
                {
                    arrayIn[i] = int.Parse(arraySt[i].Trim()); 
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error de tamaño del array");
                }
            }

            Console.WriteLine($"Tu número es {Sumas(arrayIn)}");
        }

            static int Sumas(int[] array)
            {
                int totalSuma = 0;
                int sumaIzquierda = 0;


                foreach (int num in array)
                {
                    totalSuma += num;
                }


                for (int i = 0; i < array.Length; i++)
                {

                    if (sumaIzquierda == totalSuma - sumaIzquierda - array[i])
                    {
                        return i;
                    }


                    sumaIzquierda += array[i];
                }
                return -1;
            }







        }

    }
