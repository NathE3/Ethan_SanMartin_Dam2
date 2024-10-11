using EjerciciosC_;

internal class Ejercicio3 : IEjecutarEjercicio
{
    public void Ejecutar()
    {
        Console.WriteLine("Dame una serie de números divididos por coma");
        string? numeros = Console.ReadLine();
        string[] numerosArray = numeros.Split(',');
        List<int> arrayNumeros = new List<int>();

        foreach (string numero in numerosArray)
        {
            int.TryParse(numero, out int num);
            arrayNumeros.Add(num);
        }

        int numeroMasRepetido = EncontrarNumeroMasRepetido(arrayNumeros);
        Console.WriteLine($"El número más repetido es {numeroMasRepetido}");
    }

    public int EncontrarNumeroMasRepetido(List<int> numeros)
    {
        int numeroMasRepetido = numeros[0];
        int maxRepeticiones = 0;

        foreach (int num in numeros)
        {
            int repeticiones = numeros.Count(n => n == num);
            if (repeticiones > maxRepeticiones)
            {
                maxRepeticiones = repeticiones;
                numeroMasRepetido = num;
            }
        }

        return numeroMasRepetido;
    }
}