using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Figuras
{
    public partial class Form1 : Form
    {
        Figura[] figuras;

        public Form1()
        {
            InitializeComponent();
            figuras = new Figura[5] 
            {
                new Circulo(40),
                new Rectangulo(30,50),
                new Cuadrado(60),
                new TrianguloIsosceles(50,80),
                new TrianguloEquilatero(100),
            };

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            for (int i = 0; i < figuras.Length; i++)
            {
                figuras[i].Dibujar(pen,gr,i * 100, 50);
            }

        }
    }
}
