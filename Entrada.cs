using System;

namespace EstructurasLineales
{
    /// <summary>Lectura de datos por consola con validación.</summary>
    public static class Entrada
    {
        public static int LeerEntero(string mensaje, int minimo, int maximo)
        {
            while (true)
            {
                Console.Write(mensaje);
                int valor;
                if (int.TryParse(Console.ReadLine(), out valor) && valor >= minimo && valor <= maximo)
                    return valor;

                Console.WriteLine("Entrada inválida. Ingrese un entero entre " + minimo + " y " + maximo + ".");
            }
        }
    }
}
