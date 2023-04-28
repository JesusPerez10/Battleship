using System;

namespace Battleship
{
    class Program
    {
        static int[,] tablero = new int[5, 5];
        static int intentos = 0;
        static int barcosRestantes = 4;
        static Random random = new Random();

        static void Main(string[] args)
        {
            Paso1_CrearTablero();
            Paso2_CrearBarcos();
            Paso3_ImprimirTablero();

            bool modoUnJugador = ElegirModoJuego();

            if (modoUnJugador)
            {
                JugarUnJugador();
            }
            else
            {
                JugarDosJugadores();
            }
        }

        static void Paso1_CrearTablero()
        {
            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {
                    tablero[f, c] = 0;
                }
            }
        }

        static void Paso2_CrearBarcos()
        {
            Console.WriteLine("Coloca tus barcos en el tablero.");
            Console.WriteLine("Ingresa las coordenadas (fila, columna) para cada barco.");
            Console.WriteLine("Los barcos deben tener una longitud de 1 casilla.");

            int barcosColocados = 0;

            while (barcosColocados < 4)
            {
                Console.Write("Barco #" + (barcosColocados + 1) + ": ");
                Console.Write("Ingresa la fila (0-4): ");
                int fila = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ingresa la columna (0-4): ");
                int columna = Convert.ToInt32(Console.ReadLine());

                if (fila >= 0 && fila < tablero.GetLength(0) && columna >= 0 && columna < tablero.GetLength(1) && tablero[fila, columna] == 0)
                {
                    tablero[fila, columna] = 1;
                    barcosColocados++;
                }
                else
                {
                    Console.WriteLine("Ubicación inválida. Inténtalo de nuevo.");
                }
            }

            Console.WriteLine("Barcos colocados exitosamente.");
            Console.WriteLine();
        }

        static void Paso3_ImprimirTablero()
        {
            Console.WriteLine("  0 1 2 3 4");
            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                Console.Write(f + " ");
                for (int c = 0; c < tablero.GetLength(1); c++)
                {
                    switch (tablero[f, c])
                    {
                        case 0:
                            Console.Write("~ ");
                            break;

                        case 1:
                            Console.Write("- ");
                            break;

                        case -1:
                            Console.Write("* ");
                            break;

                        case -2:
                            Console.Write("X ");
                            break;

                        default:
                            Console.Write("~ ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        static bool ElegirModoJuego()
        {
            Console.WriteLine("Elige el modo de juego:");
            Console.WriteLine("1. Un jugador (contra la computadora)");
            Console.WriteLine("2. Dos jugadores");

            int opcion;
            do
            {
                Console.Write("Ingresa el número de opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                if (opcion != 1 && opcion !=
                    2)
                {
                    Console.WriteLine("Opción inválida. Inténtalo de nuevo.");
                }
            } while (opcion != 1 && opcion != 2);

            return opcion == 1;
        }

        static void JugarUnJugador()
        {
            Console.WriteLine("¡Bienvenido al modo de un jugador!");

            while (barcosRestantes > 0)
            {
                Console.Write("Ingresa la fila (0-4): ");
                int fila = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ingresa la columna (0-4): ");
                int columna = Convert.ToInt32(Console.ReadLine());

                if (fila >= 0 && fila < tablero.GetLength(0) && columna >= 0 && columna < tablero.GetLength(1))
                {
                    if (tablero[fila, columna] == 1)
                    {
                        Console.Beep();
                        Console.WriteLine("¡Le has dado a un barco!");
                        tablero[fila, columna] = -1;
                        barcosRestantes--;
                    }
                    else if (tablero[fila, columna] == -1 || tablero[fila, columna] == -2)
                    {
                        Console.WriteLine("Ya has disparado en esta posición. Inténtalo de nuevo.");
                    }
                    else
                    {
                        Console.WriteLine("¡Fallaste!");
                        tablero[fila, columna] = -2;
                    }

                    intentos++;
                    Paso3_ImprimirTablero();
                }
                else
                {
                    Console.WriteLine("Ubicación inválida. Inténtalo de nuevo.");
                }
            }

            Console.WriteLine("¡Felicidades! ¡Has hundido todos los barcos en " + intentos + " intentos!");
        }

        static void JugarDosJugadores()
        {
            Console.WriteLine("¡Bienvenido al modo de dos jugadores!");

            int jugadorActual = 1;
            int jugadoresRestantes = 2;

            while (barcosRestantes > 0)
            {
                Console.WriteLine("Turno del Jugador " + jugadorActual);

                Console.Write("Ingresa la fila (0-4): ");
                int fila = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ingresa la columna (0-4): ");
                int columna = Convert.ToInt32(Console.ReadLine());

                if (fila >= 0 && fila < tablero.GetLength(0) && columna >= 0 && columna < tablero.GetLength(1))
                {
                    if (tablero[fila, columna] == 1)
                    {
                        Console.Beep();
                        Console.WriteLine("¡Le has dado a un barco del Jugador " + jugadorActual + "!");
                        tablero[fila, columna] = -1;
                        barcosRestantes--;
                    }
                    else if (tablero[fila, columna] == -1 || tablero[fila, columna] == -2)
                    {
                        Console.WriteLine("Ya has disparado en esta posición. Inténtalo de nuevo.");
                    }
                    else
                    {
                        Console.WriteLine("¡Fallaste!");
                        tablero[fila, columna] = -2;
                    }

                    intentos++;
                    Paso3_ImprimirTablero();
                }
                else
                {
                    Console.WriteLine("Ubicación inválida. Inténtalo de nuevo.");
                }

                jugadorActual = jugadorActual == 1 ? 2 : 1; // Cambiar al siguiente jugador

                if (jugadoresRestantes == 2)
                {
                    Console.WriteLine("¡Es el turno del Jugador " + jugadorActual + "!");
                }
                else
                {
                    Console.WriteLine("¡Felicidades! ¡Has hundido todos los barcos en " + intentos + " intentos!");
                }

                jugadoresRestantes--;
            }

            Console.WriteLine("¡Felicidades! ¡El Jugador " + jugadorActual + " ha hundido todos los barcos en " + intentos + " intentos!");
        }
    }
}