using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace simulacion
{
    public partial class FormMain : Form
    {
        List<Coordenada> listaCoordenadas;
        const int sizeSquare = 40;

        public FormMain()
        {
            InitializeComponent();
            listaCoordenadas = new List<Coordenada>();
        }

        private void dibujarCuadricula()
        {
            int x, y, height, width, linesWidth, linesHeight;
            Pen pen = new Pen(Color.Black, 2);

            height = panel1.Height;
            width = panel1.Width;
            linesWidth = width / sizeSquare;
            linesHeight = height / sizeSquare;

            y = 0; 
            for (int i = 0; i < linesWidth; i++)
            {
                x = sizeSquare * i;
                panel1.CreateGraphics().DrawLine(pen, x, y, x, height);
            }

            x = 0;
            for (int i = 0; i < linesHeight; i++)
            {
                y = sizeSquare * i;
                panel1.CreateGraphics().DrawLine(pen, x, y, width, y);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            dibujarCuadricula();
        }

        private void dibujarCoordenada(Coordenada coordenada)
        {
            Pen pen = new Pen(Color.Red, 3);
            float x, y;
            x = coordenada.getX() * sizeSquare;
            y = coordenada.getY() * sizeSquare;
            panel1.CreateGraphics().DrawEllipse(pen, x, y, 5, 5);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            float coordenadaX, coordenadaY;

            coordenadaX = e.X;
            coordenadaY = e.Y;

            coordenadaX = coordenadaX / sizeSquare;
            coordenadaY = coordenadaY / sizeSquare;

            MessageBox.Show(coordenadaX + "," + coordenadaY);

            Coordenada coordenada = new Coordenada();

            coordenada.setX(coordenadaX);
            coordenada.setY(coordenadaY);

            listaCoordenadas.Add(coordenada);

            foreach (Coordenada coordenadaI in listaCoordenadas)
            {
                Console.WriteLine(coordenadaI.getX() + "  ,  " + coordenadaI.getY());
            }
            Console.WriteLine("------Coordenadas-----------");

            dibujarCoordenada(coordenada);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("coordenadas.txt"))
            {
                foreach (Coordenada coordenadaI in listaCoordenadas)
                {
                    sw.WriteLine(coordenadaI.getX() + "-" + coordenadaI.getY());
                }
                sw.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("coordenadas.txt"))
            {
                string linea = "";
                float x, y;
                Coordenada coordenada = new Coordenada();
                listaCoordenadas.Clear();

                while (!sr.EndOfStream)
                {
                    string[] strCoordenada;

                    linea = sr.ReadLine();
                    strCoordenada = linea.Split('-');


                    x = float.Parse(strCoordenada[0]);
                    y = float.Parse(strCoordenada[1]);
                    coordenada.setX(x);
                    coordenada.setY(y);

                    Console.WriteLine(coordenada.getX() + "  -  " + coordenada.getY());

                    listaCoordenadas.Add(coordenada);

                    dibujarCoordenada(coordenada);

                }
                sr.Close();
            }
            
        }
    }
}
