using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosC_
{
    class Ejercicio11 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Dame un número: "); 
            int numero = int.Parse(Console.ReadLine()); 
            int[] resultado = CuatroCuadrados(numero); 
            Console.WriteLine($"Los cuatro números son: {resultado[0]}, {resultado[1]}, {resultado[2]}, {resultado[3]}");
        }
        public static int[] CuatroCuadrados(int numero) 
        { 
           for (int a = 0; a * a <= numero; a++) 
            { for (int b = 0; b * b <= numero; b++) 
                { for (int c = 0; c * c <= numero; c++) 
                    { for (int d = 0; d * d <= numero; d++) 
                        { if (a * a + b * b + c * c + d * d == numero) 
                            { return new int[] { a, b, c, d }; 
                            } 
                        } 
                    } 
                } 
            } return new int[] { 0, 0, 0, 0 }; }
    }
}
    
