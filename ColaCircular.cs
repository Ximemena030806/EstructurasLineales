using System;

namespace EstructurasLineales
{
    /// <summary>
    /// COLA CIRCULAR con arreglo estático. Política FIFO reutilizando todas las casillas.
    ///
    /// Idea: el arreglo se trata como un anillo; cuando un puntero llega al final vuelve a la
    /// posición 0 usando el operador módulo:   indice = (indice + 1) % capacidad.
    ///
    /// Punteros de índice:
    ///   front = índice del primer elemento.
    ///   rear  = índice del último elemento insertado (inicia en -1).
    ///   count = cantidad de elementos; permite distinguir "vacía" de "llena", porque en un anillo
    ///           ambos casos podrían dejar front y rear en posiciones equivalentes.
    /// </summary>
    public class ColaCircular<T>
    {
        private readonly T[] datos;
        private int front;
        private int rear;
        private int count;

        public int Capacity { get { return datos.Length; } }
        public int Count { get { return count; } }

        public ColaCircular(int capacidad)
        {
            if (capacidad <= 0)
                throw new ArgumentOutOfRangeException("capacidad", "La capacidad debe ser mayor que cero.");

            datos = new T[capacidad];
            front = 0;
            rear = -1;
            count = 0;
        }

        public bool IsEmpty() { return count == 0; }
        public bool IsFull() { return count == datos.Length; }

        // Enqueue: rear avanza de forma circular y se guarda el elemento
        public void Enqueue(T elemento)
        {
            if (IsFull())
                throw new InvalidOperationException("Cola circular llena: no hay casillas libres.");

            rear = (rear + 1) % datos.Length;  // Vuelve a 0 al pasar la última casilla
            datos[rear] = elemento;
            count++;
        }

        // Dequeue: se lee front y este avanza de forma circular
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cola circular vacía: no hay elementos que retirar.");

            T elemento = datos[front];
            datos[front] = default(T);
            front = (front + 1) % datos.Length; // Vuelve a 0 al pasar la última casilla
            count--;
            return elemento;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cola circular vacía: no hay frente que consultar.");

            return datos[front];
        }

        // Una casilla i está ocupada si su distancia circular desde front es menor que count.
        public void Imprimir()
        {
            Console.WriteLine("   COLA CIRCULAR  (Capacity = " + Capacity + ", Count = " + Count +
                              ", front = " + front + ", rear = " + rear + ")");

            string fila = "   [ ";
            string indices = "     ";
            for (int i = 0; i < datos.Length; i++)
            {
                bool ocupada = ((i - front + datos.Length) % datos.Length) < count;
                string celda = ocupada ? datos[i].ToString() : "_";
                fila += celda;

                // Alinea los índices debajo de cada celda
                indices += i.ToString().PadRight(celda.Length);

                if (i < datos.Length - 1) { fila += " | "; indices += "   "; }
            }
            Console.WriteLine(fila + " ]");
            Console.WriteLine(indices + "   (índices)");
        }
    }
}
