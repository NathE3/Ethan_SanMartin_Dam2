
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EjerciciosC_
{
    public class Ejercicio12 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Fila inicial sin espacios: ");
            string filaInicial = Console.ReadLine();
            Console.WriteLine();

            char ultimoColor = DibujarTriangulo(filaInicial);
            Console.WriteLine();

            Console.WriteLine("El color en la punta del triángulo es: " + ultimoColor);
        }

        
        public static char DibujarTriangulo(string fila)
        {
            int longitudInicial = fila.Length;

            
            while (fila.Length > 1)
            {
                ImprimirFila(fila, longitudInicial);

              
                char[] nuevaFila = new char[fila.Length - 1];
                for (int i = 0; i < fila.Length - 1; i++)
                {
                    if (fila[i] == fila[i + 1])
                    {
                        nuevaFila[i] = fila[i];
                    }
                    else
                    {
                        nuevaFila[i] = Faltante(fila[i], fila[i + 1]);
                    }
                }

                fila = new string(nuevaFila);
            }

           
            ImprimirFila(fila, longitudInicial);
            return fila[0];
        }

        public static void ImprimirFila(string fila, int longitudInicial)
        {
            int espacios = (longitudInicial - fila.Length) / 2; 
            Console.Write(new string(' ', espacios)); 
            Console.WriteLine(fila); 
        }

        public static char Faltante(char a, char b)
        {
            if ((a == 'R' && b == 'G') || (a == 'G' && b == 'R'))
                return 'B'; 
            if ((a == 'R' && b == 'B') || (a == 'B' && b == 'R'))
                return 'G'; 
            if ((a == 'G' && b == 'B') || (a == 'B' && b == 'G'))
                return 'R'; 

            return ' '; 
        }

    }
}





