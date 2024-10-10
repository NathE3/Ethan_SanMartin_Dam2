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
        { Console.WriteLine("Fila inicial: "); 
            string filaInicial = Console.ReadLine(); 
            string colorFinal = PintarTriangulo(filaInicial); 
            Console.WriteLine($"Color final: {colorFinal}"); }
        public static string PintarTriangulo(string fila) 
        { while (fila.Length > 1) 
            { 
                char[] nuevaFila = new char[fila.Length - 1]; 
                for (int i = 0; i < fila.Length - 1; i++) 
                { 
                    if (fila[i] == fila[i + 1]) 
                    {
                        nuevaFila[i] = fila[i]; 
                    } 
                    else 
                    { 
                        nuevaFila[i] = LaQueFalta(fila[i], fila[i + 1]); 
                    } 
                } 
                fila = new string(nuevaFila); 
            } 
            return fila; 
        }
        public static char LaQueFalta(char a, char b) 
        { 
            if ((a == 'R' && b == 'G') || (a == 'G' && b == 'R')) return 'B'; if ((a == 'R' && b == 'B') || (a == 'B' && b == 'R')) 
                return 'G'; return 'R'; 
        }
    }
}

