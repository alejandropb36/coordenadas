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
        public FormMain()
        {
            InitializeComponent();
        }

        private void DibujarLineas()
        {
            int x, y, heigth, width;
            Pen pen = new Pen(Color.Black, 2);

            heigth = panel1.Height;
            width = panel1.Width;

            y = 0; 
            for (int i = 0; i < 200; i++)
            {
                x = 40 * i;
                panel1.CreateGraphics().DrawLine(pen, x, y, x, heigth);
            }

            x = 0;
            for (int i = 0; i < 200; i++)
            {
                y = 40 * i;
                panel1.CreateGraphics().DrawLine(pen, x, y, width, y);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DibujarLineas();
        }
    }
}
