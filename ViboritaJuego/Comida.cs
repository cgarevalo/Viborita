using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;// Point se puede utilizar gracias a este using

namespace ViboritaJuego
{
    internal class Comida
    {
        public Point Posicion { get; set; }
        public ConsoleColor Color { get; set; }
        public Ventana VentanaC2 { get; set; }

        public Comida(ConsoleColor color, Ventana ventana)
        {
            Color = color;
            VentanaC2 = ventana;
        }

        public void DibujarComida()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition((int)Posicion.X, (int)Posicion.Y);
            Console.Write("❤");
        }

        public bool GenerarComida(Serpiente serpiente)
        {
            int serpienteLong = serpiente.Cuerpo.Count + 1;
            if ((VentanaC2.Area - serpienteLong) <= 0) 
            {
                return false;
            }

            Random random = new Random();
            int x = random.Next((int)VentanaC2.LimiteSuperior.X + 1, (int)VentanaC2.LimiteInferior.X);
            int y = random.Next((int)VentanaC2.LimiteSuperior.Y + 1, (int)VentanaC2.LimiteInferior.Y);
            Posicion = new Point(x, y);

            foreach (Point i in serpiente.Cuerpo)
            {
                if (x == i.X && y == i.Y || (x == serpiente.Cabeza.X && y == serpiente.Cabeza.Y))
                {
                    // Esto se llama recursividad
                    if (GenerarComida(serpiente))
                    {
                        return true;
                    }
                }
            }

            DibujarComida();
            return true;
        }
    }
}
