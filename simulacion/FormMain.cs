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
        List<Coordenada> absolutas;
        List<Coordenada> relativas;
        const int sizeSquare = 20;

        public FormMain()
        {
            InitializeComponent();
            absolutas = new List<Coordenada>();
            relativas = new List<Coordenada>();
        }

        private void dibujarCuadricula()
        {
            int x, y, height, width, linesWidth, linesHeight;
            Pen pen = new Pen(Color.Black, 1);

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
            Pen pen = new Pen(Color.Blue, 3);
            int x, y;
            x = coordenada.getX() * sizeSquare;
            y = coordenada.getY() * sizeSquare;
            panel1.CreateGraphics().DrawEllipse(pen, x - 2, y - 2, 5, 5);
        }

        private void guardaCoordenada(int x, int y)
        {
            int coordenadaX, coordenadaY;

            coordenadaX = x;
            coordenadaY = y;

            coordenadaX = coordenadaX / sizeSquare;
            coordenadaY = coordenadaY / sizeSquare;

            toolStripStatusLabel1.Text = coordenadaX + "," + coordenadaY;
            //MessageBox.Show(coordenadaX + "," + coordenadaY);

            Coordenada coordenada = new Coordenada();

            coordenada.setX(coordenadaX);
            coordenada.setY(coordenadaY);

            absolutas.Add(coordenada);

            Console.WriteLine("------Coordenadas-----------");
            foreach (Coordenada coordenadaI in absolutas)
            {
                Console.WriteLine(coordenadaI.getX() + "  ,  " + coordenadaI.getY());
            }

            dibujarCoordenada(coordenada);
            imprimirCoordenadas(absolutas, listView1);
            coordenadasRelativas(absolutas, relativas);
            imprimirCoordenadas(relativas, listView2);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            guardaCoordenada(e.X, e.Y);
        }

        private void saveFile()
        {
            using (StreamWriter sw = new StreamWriter("coordenadas.txt"))
            {
                string linea = "";
                foreach (Coordenada coordenadaI in absolutas)
                {
                    linea = coordenadaI.getX().ToString() + "," + coordenadaI.getY().ToString();
                    sw.WriteLine(linea);
                }
                sw.Close();
            }
        }

        // Boton de guardado
        private void button1_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void loadFile()
        {
            panel1.Refresh();
            if (File.Exists("coordenadas.txt"))
            {
                absolutas.Clear();
                using (StreamReader sr = new StreamReader("coordenadas.txt"))
                {
                    string linea = "";
                    int x, y;

                    while (!sr.EndOfStream)
                    {
                        Coordenada coordenada = new Coordenada();
                        string[] strCoordenada;

                        linea = sr.ReadLine();
                        strCoordenada = linea.Split(',');


                        x = int.Parse(strCoordenada[0]);
                        y = int.Parse(strCoordenada[1]);
                        coordenada.setX(x);
                        coordenada.setY(y);

                        Console.WriteLine(coordenada.getX() + "  -  " + coordenada.getY());

                        absolutas.Add(coordenada);

                        dibujarCoordenada(coordenada);
                    }
                    sr.Close();
                }
                imprimirCoordenadas(absolutas, listView1);
                coordenadasRelativas(absolutas, relativas);
                imprimirCoordenadas(relativas, listView2);
            }
            else
            {
                MessageBox.Show("No existe el archivo coordenadas.txt");
            }
            dibujarCuadricula();
        }

        // Boton de carga
        private void button2_Click(object sender, EventArgs e)
        {
            loadFile();
        }

        private void imprimirCoordenadas(List<Coordenada> listaCoordenadas, ListView listView)
        {
            listView.Items.Clear();
            string[] arrString = new string[3];
            int i = 0;

            foreach(Coordenada coordenadaI in listaCoordenadas)
            {
                arrString[0] = i.ToString();
                arrString[1] = coordenadaI.getX().ToString();
                arrString[2] = coordenadaI.getY().ToString();
                ListViewItem item = new ListViewItem(arrString);
                listView.Items.Add(item);
                i++;
            }
        }

        private void coordenadasRelativas(List<Coordenada> absolutas, List<Coordenada> relativas)
        {
            if (absolutas.Count != 0)
            {
                int x, y;
                relativas.Clear();
                relativas.Add(absolutas[0]);

                for (int i = 1; i < absolutas.Count; i++)
                {
                    Coordenada coordenada = new Coordenada();
                    x = absolutas[i].getX() - absolutas[i - 1].getX();
                    y = absolutas[i].getY() - absolutas[i - 1].getY();
                    coordenada.setX(x);
                    coordenada.setY(y);
                    relativas.Add(coordenada);
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "No hay coordenadas que cargar";
            }
            
        }
    }
}
