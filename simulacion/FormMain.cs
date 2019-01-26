using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simulacion
{
    public partial class FormMain : Form
    {
        List<Point> points;

        public FormMain()
        {
            InitializeComponent();
        }

        private void DibujarLineas()
        {
            int x, y, height, width, linesWidth, linesHeight;
            const int sizeSquare = 40;
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
            DibujarLineas();
        }
    }
}
