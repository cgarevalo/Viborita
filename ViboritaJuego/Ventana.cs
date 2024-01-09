using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Drawing;
using System.Windows; // Point se puede utilizar gracias a este using

namespace ViboritaJuego
{
    internal class Ventana
    {
        public string Titulo { get; set; }
        public int Altura { get; set; }
        public int Ancho { get; set; }
        public ConsoleColor ColorFondo { get; set; }
        public ConsoleColor ColorLetra { get; set; }
        public Point LimiteSuperior { get; set; }
        public Point LimiteInferior { get; set; }
        public int Area { get; set; }
        public Serpiente SerpienteC { get; set; }


        // Constructor
        public Ventana(string titulo, int ancho, int altura, ConsoleColor colorFondo, ConsoleColor colorLetra, Point limiteSuperior, Point limiteInferior) 
        {
            Titulo = titulo;
            Altura = altura;
            Ancho = ancho;
            ColorFondo = colorFondo;
            ColorLetra = colorLetra;
            LimiteSuperior = limiteSuperior;
            LimiteInferior = limiteInferior;
            Area = (((int)LimiteInferior.X - (int)LimiteSuperior.X) - 1) * (((int)LimiteInferior.Y - (int)LimiteSuperior.Y) - 1); //Calcula el área del marco del juego
            Init();
        }

        private void Init()
        {
            Console.SetWindowSize(Ancho, Altura);
            Console.Title = Titulo;
            Console.CursorVisible = false;
            Console.BackgroundColor = ColorFondo;
            Console.Clear();
            SerpienteC = new Serpiente(new Point(LimiteInferior.X / 2, LimiteInferior.Y - 3), ConsoleColor.Magenta, ConsoleColor.White, this, null);
            SerpienteC.IniciarCuerpo(4);
        }

        //Método que dibuja el marco del juego
        public void DibujarMarco()
        {
            Console.ForegroundColor = ColorLetra;

            for (int i = (int)LimiteSuperior.X; i < LimiteInferior.X; i++)
            {
                Console.SetCursorPosition(i, (int)LimiteSuperior.Y);
                Console.Write("═");
                Console.SetCursorPosition(i, (int)LimiteInferior.Y);
                Console.Write("═");
            }

            for (int i = (int)LimiteSuperior.Y; i < LimiteInferior.Y; i++)
            {
                Console.SetCursorPosition((int)LimiteSuperior.X, i);
                Console.Write("║");
                Console.SetCursorPosition((int)LimiteInferior.X, i);
                Console.Write("║");
            }

            Console.SetCursorPosition((int)LimiteSuperior.X, (int)LimiteSuperior.Y);
            Console.Write("╔");
            Console.SetCursorPosition((int)LimiteSuperior.X, (int)LimiteInferior.Y);
            Console.Write("╚");
            Console.SetCursorPosition((int)LimiteInferior.X, (int)LimiteSuperior.Y);
            Console.Write("╗");
            Console.SetCursorPosition((int)LimiteInferior.X, (int)LimiteInferior.Y);
            Console.Write("╝");
        }

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((int)LimiteSuperior.X + ((int)LimiteInferior.X / 2) - 12, (int)LimiteSuperior.Y + ((int)LimiteInferior.Y / 2) - 4);
            Console.Write("JUEGO DE LA VIBORITA");

            Console.SetCursorPosition((int)LimiteSuperior.X + ((int)LimiteInferior.X / 2) - 8, (int)LimiteSuperior.Y + ((int)LimiteInferior.Y / 2) - 2);
            Console.Write("Enter - Jugar");

            Console.SetCursorPosition((int)LimiteSuperior.X + ((int)LimiteInferior.X / 2) - 8, (int)LimiteSuperior.Y + ((int)LimiteInferior.Y / 2) - 1);
            Console.Write("Esc - Salir");

            SerpienteC.MoverMenu();
        }

        public void Teclado(ref bool ejecucion, ref bool jugar, Serpiente serpiente)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.Enter)
                {
                    jugar = true;
                    Console.Clear();
                    DibujarMarco();
                    serpiente.Init();
                }

                if (tecla.Key == ConsoleKey.Escape)
                {
                    ejecucion = false;
                }
            }
        }

        public void GameOver(string texto)
        {
            Console.Clear();
            DibujarMarco();
            Console.SetCursorPosition((int)LimiteSuperior.X + ((int)LimiteInferior.X / 2) - 10, (int)LimiteSuperior.Y + ((int)LimiteInferior.Y / 2) - 2);
            Console.Write(texto);
            Thread.Sleep(3000);
            Console.Clear();
            DibujarMarco();
        }
    }
}
