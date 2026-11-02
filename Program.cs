using System;
using System.Text;

namespace EstructurasLineales
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("   ESTRUCTURAS LINEALES CON MEMORIA ESTÁTICA");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Pila (Push, Pop, Peek, isEmpty, isFull)");
                Console.WriteLine("2. Cola simple");
                Console.WriteLine("3. Cola circular");
                Console.WriteLine("4. Comparación: cola simple vs. cola circular");
                Console.WriteLine("5. Aplicación de la pila: paréntesis balanceados");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1": MenuPila(); break;
                    case "2": MenuColaSimple(); break;
                    case "3": MenuColaCircular(); break;
                    case "4": CompararColas(); break;
                    case "5": ParentesisBalanceados(); break;
                    case "0": salir = true; break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
            }
        }

        // ------------------------------------------------------------ Pila interactiva
        private static void MenuPila()
        {
            int capacidad = Entrada.LeerEntero("Capacidad de la pila (1 - 15): ", 1, 15);
            PilaEstatica<int> pila = new PilaEstatica<int>(capacidad);
            pila.Imprimir();

            bool volver = false;
            while (!volver)
            {
                Console.WriteLine("\n1.Push  2.Pop  3.Peek  4.isEmpty  5.isFull  6.Imprimir  0.Volver");
                Console.Write("Opción: ");
                string op = Console.ReadLine();

                try
                {
                    switch (op)
                    {
                        case "1":
                            pila.Push(Entrada.LeerEntero("Valor: ", int.MinValue, int.MaxValue));
                            pila.Imprimir();
                            break;
                        case "2":
                            Console.WriteLine("   Pop -> " + pila.Pop());
                            pila.Imprimir();
                            break;
                        case "3":
                            Console.WriteLine("   Peek -> " + pila.Peek());
                            break;
                        case "4":
                            Console.WriteLine("   isEmpty -> " + pila.IsEmpty());
                            break;
                        case "5":
                            Console.WriteLine("   isFull -> " + pila.IsFull());
                            break;
                        case "6":
                            pila.Imprimir();
                            break;
                        case "0":
                            volver = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("   Error: " + ex.Message);
                }
            }
        }

        // ------------------------------------------------------------ Cola simple interactiva
        private static void MenuColaSimple()
        {
            int capacidad = Entrada.LeerEntero("Capacidad de la cola (1 - 15): ", 1, 15);
            ColaSimple<int> cola = new ColaSimple<int>(capacidad);
            cola.Imprimir();

            bool volver = false;
            while (!volver)
            {
                Console.WriteLine("\n1.Enqueue  2.Dequeue  3.Peek  4.isEmpty  5.isFull  6.Imprimir  0.Volver");
                Console.Write("Opción: ");
                string op = Console.ReadLine();

                try
                {
                    switch (op)
                    {
                        case "1":
                            cola.Enqueue(Entrada.LeerEntero("Valor: ", int.MinValue, int.MaxValue));
                            cola.Imprimir();
                            break;
                        case "2":
                            Console.WriteLine("   Dequeue -> " + cola.Dequeue());
                            cola.Imprimir();
                            break;
                        case "3":
                            Console.WriteLine("   Peek -> " + cola.Peek());
                            break;
                        case "4":
                            Console.WriteLine("   isEmpty -> " + cola.IsEmpty());
                            break;
                        case "5":
                            Console.WriteLine("   isFull -> " + cola.IsFull());
                            break;
                        case "6":
                            cola.Imprimir();
                            break;
                        case "0":
                            volver = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("   Error: " + ex.Message);
                }
            }
        }

        // ------------------------------------------------------------ Cola circular interactiva
        private static void MenuColaCircular()
        {
            int capacidad = Entrada.LeerEntero("Capacidad de la cola (1 - 15): ", 1, 15);
            ColaCircular<int> cola = new ColaCircular<int>(capacidad);
            cola.Imprimir();

            bool volver = false;
            while (!volver)
            {
                Console.WriteLine("\n1.Enqueue  2.Dequeue  3.Peek  4.isEmpty  5.isFull  6.Imprimir  0.Volver");
                Console.Write("Opción: ");
                string op = Console.ReadLine();

                try
                {
                    switch (op)
                    {
                        case "1":
                            cola.Enqueue(Entrada.LeerEntero("Valor: ", int.MinValue, int.MaxValue));
                            cola.Imprimir();
                            break;
                        case "2":
                            Console.WriteLine("   Dequeue -> " + cola.Dequeue());
                            cola.Imprimir();
                            break;
                        case "3":
                            Console.WriteLine("   Peek -> " + cola.Peek());
                            break;
                        case "4":
                            Console.WriteLine("   isEmpty -> " + cola.IsEmpty());
                            break;
                        case "5":
                            Console.WriteLine("   isFull -> " + cola.IsFull());
                            break;
                        case "6":
                            cola.Imprimir();
                            break;
                        case "0":
                            volver = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("   Error: " + ex.Message);
                }
            }
        }

        // ------------------------------------------------------------ Comparación automática
        // Misma secuencia sobre ambas colas: se llenan, se retiran 3 elementos y se intenta insertar uno más.
        private static void CompararColas()
        {
            Console.WriteLine("=== COLA SIMPLE vs COLA CIRCULAR (capacidad 5) ===\n");
            ColaSimple<int> simple = new ColaSimple<int>(5);
            ColaCircular<int> circular = new ColaCircular<int>(5);

            Console.WriteLine("1) Se insertan 10, 20, 30, 40, 50 en ambas:");
            for (int i = 1; i <= 5; i++)
            {
                simple.Enqueue(i * 10);
                circular.Enqueue(i * 10);
            }
            simple.Imprimir();
            circular.Imprimir();

            Console.WriteLine("\n2) Se retiran 3 elementos (Dequeue x3) en ambas:");
            for (int i = 0; i < 3; i++)
            {
                simple.Dequeue();
                circular.Dequeue();
            }
            simple.Imprimir();
            circular.Imprimir();

            Console.WriteLine("\n3) Se intenta insertar 60 en ambas:");
            try
            {
                simple.Enqueue(60);
                Console.WriteLine("   Cola simple: insertado.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("   Cola simple    -> ERROR: " + ex.Message);
            }

            circular.Enqueue(60);
            Console.WriteLine("   Cola circular  -> insertado (rear dio la vuelta al inicio del arreglo):");
            circular.Imprimir();

            Console.WriteLine("\nConclusión: la cola circular reutiliza las casillas liberadas; la simple las desperdicia.");
        }

        // ------------------------------------------------------------ Aplicación de la pila
        // Verifica que (), [] y {} estén balanceados: se apilan las aperturas y cada cierre
        // debe coincidir con la cima.
        private static void ParentesisBalanceados()
        {
            Console.Write("Expresión (ej: {[(a+b)*c]-d}): ");
            string texto = Console.ReadLine() ?? "";

            // Como mucho se apilan tantos símbolos como caracteres tenga el texto.
            PilaEstatica<char> pila = new PilaEstatica<char>(Math.Max(1, texto.Length));
            bool balanceada = true;

            foreach (char ch in texto)
            {
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    pila.Push(ch);
                }
                else if (ch == ')' || ch == ']' || ch == '}')
                {
                    if (pila.IsEmpty()) { balanceada = false; break; } // cierre sin apertura

                    char apertura = pila.Pop();
                    bool coincide = (apertura == '(' && ch == ')') ||
                                    (apertura == '[' && ch == ']') ||
                                    (apertura == '{' && ch == '}');
                    if (!coincide) { balanceada = false; break; }
                }
            }

            if (!pila.IsEmpty()) balanceada = false; // quedaron aperturas sin cerrar
            Console.WriteLine(balanceada ? "   ✔ Expresión balanceada." : "   ✘ Expresión NO balanceada.");
        }
    }
}
