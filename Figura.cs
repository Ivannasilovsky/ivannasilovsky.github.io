using System;
using System.Drawing;

namespace Figuras
{
    public class Figura
    {
        protected Color colorFigura;
        protected static Random random = new Random();
        
        public virtual void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
        }
        
        protected Color GenerarColorAleatorio()
        {
            int r = random.Next(0, 256);  
            int g = random.Next(0, 256); 
            int b = random.Next(0, 256);  
            
            return Color.FromArgb(r, g, b);
        }
        
        public void SetColor(Color color)
        {
            this.colorFigura = color;
        }
    }

    public class Rectangulo : Figura
    {
        protected int alto;
        protected int ancho;
        
        public Rectangulo(int ancho, int alto)
        {
            this.ancho = ancho;
            this.alto = alto;

            this.colorFigura = GenerarColorAleatorio();
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            pen.Color = this.colorFigura;
            
            Point[] points = new Point[4]
            {
                new Point(x, y),
                new Point(x + ancho, y),
                new Point(x + ancho, y + alto),
                new Point(x, y + alto)
            };
            
            graphics.DrawPolygon(pen, points);
        }
    }

    public class Cuadrado : Rectangulo
    {
        public Cuadrado(int lado) : base(lado, lado)
        {
            this.colorFigura = GenerarColorAleatorio();
        }
    }

    public class Circulo : Figura
    {
        private int radio;
        
        public Circulo(int radio)
        {
            this.radio = radio;
            this.colorFigura = GenerarColorAleatorio();
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            pen.Color = this.colorFigura;
            
            graphics.DrawEllipse(pen, x, y, radio, radio);
        }
    }

    public class TrianguloIsosceles : Figura
    {
    private int baseTriangulo;
    private int altura;

        public TrianguloIsosceles(int baseTriangulo, int altura)
        {
            this.baseTriangulo = baseTriangulo;
            this.altura = altura;
            this.colorFigura = GenerarColorAleatorio();
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            pen.Color = this.colorFigura;

            Point[] points = new Point[3]
            {
                new Point(x, y + altura),
                new Point(x + baseTriangulo / 2, y),
                new Point(x + baseTriangulo, y + altura)
            };

            graphics.DrawPolygon(pen, points);
        }
    }

    public class TrianguloEquilatero : Figura
    {
        private int lado;

        public TrianguloEquilatero(int lado)
        {
            this.lado = lado;
            this.colorFigura = GenerarColorAleatorio();
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            pen.Color = this.colorFigura;

            double altura = Math.Sqrt(3) / 2 * lado;

            Point[] points = new Point[3]
            {
                new Point(x, (int)(y + altura)),
                new Point(x + lado / 2, y),
                new Point(x + lado, (int)(y + altura))
            };

            graphics.DrawPolygon(pen, points);
        }
    }
}