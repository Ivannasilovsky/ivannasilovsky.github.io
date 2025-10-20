using System;
using System.Drawing;

namespace Figuras
{
    public class Figura
    {
        protected Color colorFigura;
        
        public virtual void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
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
        
        // Constructor
        public Rectangulo(int ancho, int alto)
        {
            this.ancho = ancho;
            this.alto = alto;
            this.colorFigura = Color.Blue;
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
        
            this.colorFigura = Color.Green;
        }
    }

    public class Circulo : Figura
    {
        private int radio;
        
        
        public Circulo(int radio)
        {
            this.radio = radio;
      
            this.colorFigura = Color.Red;
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
        
            pen.Color = this.colorFigura;
            
            graphics.DrawEllipse(pen, x, y, radio, radio);
        }
    }
}