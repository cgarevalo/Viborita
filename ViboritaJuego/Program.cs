using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;// Point se puede utilizar gracias a este using

namespace ViboritaJuego
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ventana ventana;
            Serpiente serpiente;
            Comida comida;
            bool jugar = false;
            bool ejecucion = true;

            void Iniciar()
            {
                ventana = new Ventana("Viborita", 65, 20, ConsoleColor.Black, ConsoleColor.White, new Point(5, 3), new Point(59, 18));
                ventana.DibujarMarco();

                comida = new Comida(ConsoleColor.Red, ventana);

                serpiente = new Serpiente(new Point(8, 5), ConsoleColor.Red, ConsoleColor.White, ventana, comida);
            }

            void Game()
            {
                while (ejecucion)
                {
                    ventana.Menu();
                    ventana.Teclado(ref ejecucion, ref jugar, serpiente);

                    while (jugar)
                    {
                        serpiente.Informacion(0, 38);
                        serpiente.Mover();

                        if (!serpiente.Vivo)
                        {
                            jugar = false;
                            serpiente.Puntaje = 0;

                        }

                        Thread.Sleep(50);
                    }

                    Thread.Sleep(50); // Para disminuir la velocidad de la serpiente del menú
                }  
            }


            Iniciar();
            Game();
        }
    }
}
