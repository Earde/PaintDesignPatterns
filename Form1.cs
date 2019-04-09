using PaintDesignPatterns.Drawers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintDesignPatterns
{
    public partial class Form1 : Form
    {
        bool mouseDown = false;

        Drawer drawer = null;
        BasicShape tempShape = null;

        List<Shape> shapes;

        public Form1()
        {
            InitializeComponent();
            shapes = new List<Shape>();
        }

        private void drawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                tempShape.Resize(e.X, e.Y);
                drawPanel.Invalidate();
            }
        }

        private void drawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            tempShape = new BasicShape(new Point(e.X, e.Y), new Point(e.X, e.Y), drawer, new Pen(Brushes.Gray, 3.0f));
            mouseDown = true;
            drawPanel.Invalidate();
        }

        private void drawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            drawPanel.Invalidate();
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            if (mouseDown && drawer != null)
            {
                tempShape.Draw(e.Graphics);
            }
        }

        private void btnRect_Click(object sender, EventArgs e)
        {
            drawer = new RectangleDrawer();
        }

        private void btnEllips_Click(object sender, EventArgs e)
        {
            drawer = new EllipsDrawer();
        }
    }
}