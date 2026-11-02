using System;

namespace EstructurasLineales
{
    /// <summary>
    /// PILA (Stack) con arreglo estático. Política LIFO: el último en entrar es el primero en salir.
    ///
    /// Memoria estática: el arreglo se reserva UNA sola vez con la capacidad indicada y
    /// nunca cambia de tamaño. No se usa ninguna colección nativa (List, Stack, Queue...).
    ///
    /// Puntero de índice:
    ///   top = índice de la cima. Pila vacía -> top = -1. Pila llena -> top = capacidad - 1.
    /// </summary>
    public class PilaEstatica<T>
    {
        private readonly T[] datos;  // Arreglo de tamaño fijo
        private int top;             // Índice del último elemento insertado

        public int Capacity { get { return datos.Length; } }
        public int Count { get { return top + 1; } }

        public PilaEstatica(int capacidad)
        {
            if (capacidad <= 0)
                throw new ArgumentOutOfRangeException("capacidad", "La capacidad debe ser mayor que cero.");

            datos = new T[capacidad];
            top = -1; // Pila vacía
        }

        // isEmpty: no hay elementos cuando top == -1
        public bool IsEmpty() { return top == -1; }

        // isFull: no hay espacio cuando top llegó a la última posición
        public bool IsFull() { return top == datos.Length - 1; }

        // Push: 1) verificar desbordamiento (overflow)  2) avanzar top  3) guardar el elemento
        public void Push(T elemento)
        {
            if (IsFull())
                throw new InvalidOperationException("Desbordamiento (overflow): la pila está llena.");

            top++;
            datos[top] = elemento;
        }

        // Pop: 1) verificar subdesbordamiento (underflow)  2) leer la cima  3) retroceder top
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Subdesbordamiento (underflow): la pila está vacía.");

            T elemento = datos[top];
            datos[top] = default(T); // Se limpia la casilla (buena práctica con tipos por referencia)
            top--;
            return elemento;
        }

        // Peek: devuelve la cima SIN retirarla (top no cambia)
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("La pila está vacía: no hay cima que consultar.");

            return datos[top];
        }

        // Dibuja la pila de la cima hacia la base, mostrando también las casillas libres.
        public void Imprimir()
        {
            Console.WriteLine("   PILA  (Capacity = " + Capacity + ", Count = " + Count + ", top = " + top + ")");
            for (int i = datos.Length - 1; i >= 0; i--)
            {
                string contenido = i <= top ? datos[i].ToString() : "";
                string marca = i == top ? "  <-- top" : "";
                Console.WriteLine("   [" + i + "] | " + contenido.PadRight(8) + " |" + marca);
            }
            Console.WriteLine("        +----------+");
        }
    }
}
