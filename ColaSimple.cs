using System;

namespace EstructurasLineales
{
    /// <summary>
    /// COLA SIMPLE (lineal) con arreglo estático. Política FIFO: el primero en entrar es el primero en salir.
    ///
    /// Punteros de índice:
    ///   front = índice del primer elemento (el próximo en salir).
    ///   rear  = índice del último elemento insertado.
    ///   Cola vacía -> front = 0 y rear = -1.
    ///
    /// LIMITACIÓN (motivo de existir de la cola circular): al hacer Dequeue, front avanza y las
    /// casillas anteriores NO se reutilizan. Cuando rear llega al final, la cola se considera
    /// llena aunque haya casillas libres al inicio del arreglo (espacio desperdiciado).
    /// Solo se reinician los punteros cuando la cola se vacía por completo.
    /// </summary>
    public class ColaSimple<T>
    {
        private readonly T[] datos;
        private int front;
        private int rear;

        public int Capacity { get { return datos.Length; } }
        public int Count { get { return rear - front + 1; } }

        public ColaSimple(int capacidad)
        {
            if (capacidad <= 0)
                throw new ArgumentOutOfRangeException("capacidad", "La capacidad debe ser mayor que cero.");

            datos = new T[capacidad];
            front = 0;
            rear = -1;
        }

        // isEmpty: front pasó a rear (o nunca hubo elementos)
        public bool IsEmpty() { return rear < front; }

        // isFull: rear está en la última casilla (aunque queden huecos delante de front)
        public bool IsFull() { return rear == datos.Length - 1; }

        // Enqueue: se inserta SIEMPRE por el final (rear)
        public void Enqueue(T elemento)
        {
            if (IsFull())
                throw new InvalidOperationException(
                    "Cola llena: rear llegó al final del arreglo" +
                    (front > 0 ? " (hay " + front + " casilla(s) libre(s) desperdiciada(s) al inicio)." : "."));

            rear++;
            datos[rear] = elemento;
        }

        // Dequeue: se retira SIEMPRE por el frente (front)
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cola vacía: no hay elementos que retirar.");

            T elemento = datos[front];
            datos[front] = default(T);
            front++;

            // Si la cola quedó vacía, se reinician los punteros para reutilizar todo el arreglo.
            if (front > rear)
            {
                front = 0;
                rear = -1;
            }
            return elemento;
        }

        // Peek: consulta el elemento del frente sin retirarlo
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cola vacía: no hay frente que consultar.");

            return datos[front];
        }

        // Muestra el arreglo: '_' = libre, '.' = casilla ya usada y perdida (desperdicio)
        public void Imprimir()
        {
            Console.WriteLine("   COLA SIMPLE  (Capacity = " + Capacity + ", Count = " + Count +
                              ", front = " + front + ", rear = " + rear + ")");
            string fila = "   [ ";
            for (int i = 0; i < datos.Length; i++)
            {
                if (i >= front && i <= rear) fila += datos[i];
                else if (i < front) fila += ".";
                else fila += "_";

                if (i < datos.Length - 1) fila += " | ";
            }
            Console.WriteLine(fila + " ]");
            Console.WriteLine("   ('.' = casilla desperdiciada, '_' = libre)");
        }
    }
}
