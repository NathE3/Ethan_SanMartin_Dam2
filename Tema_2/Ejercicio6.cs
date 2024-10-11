using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EjerciciosC_
{
    class Ejercicio6 : IEjecutarEjercicio
    {
          public void Ejecutar()
            {
                Console.WriteLine("Dame un número: ");
                int num = int.Parse(Console.ReadLine());

                Console.WriteLine($"Tu indice es: {Repeticiones(num)}");
                 
            }

            public int Repeticiones(int num)
            {
                int cont = 0;

                while (num > 10)
                {
                    num = MultiplicarDig(num);
                    cont++;

                }
                return cont;
            }

            public int MultiplicarDig(int num)
            {

                int mult = 1;

                while (num > 0)
                {
                    mult *= num % 10;
                    num /= 10;
                }
                return mult;

            }
        }

    }


