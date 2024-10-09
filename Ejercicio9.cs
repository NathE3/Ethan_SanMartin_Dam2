using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosC_
{
    class Ejercicio9 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Introduce un número entero no negativo:");
            int num = int.Parse(Console.ReadLine());

            int resultado = OrdenarReves(num);
            Console.WriteLine("El numero mas grande con esos números es: " + resultado);
        }

        static int OrdenarReves(int num)
        {
            char[] digitos = num.ToString().ToCharArray();
            Array.Sort(digitos);
            Array.Reverse(digitos);
            return int.Parse(new string(digitos));
        }
    }
}
    

