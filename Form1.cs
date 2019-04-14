using PaintDesignPatterns.Commands;
using PaintDesignPatterns.Drawers;
using PaintDesignPatterns.Shapes;
using PaintDesignPatterns.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintDesignPatterns
{
    public partial class Form1 : Form
    {
        //Button handlers
        bool mouseDown = false;
        IState state = new RectangleState();

        Context context;

        public Form1()
        {
            InitializeComponent();
            context = new Context(this.drawPanel);
        }

        private void drawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                state.handleMouseMove(ref context, e);
            }
        }

        private void drawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            state.handleMouseDown(ref context, e);
            mouseDown = true;
        }

        private void drawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            state.handleMouseUp(ref context, e);
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            if (mouseDown && context.tempShape != null)
            {
                context.tempShape.Draw(e.Graphics);
            }
            foreach (Shape shape in context.shapes)
            {
                shape.Draw(e.Graphics);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (context.undoStack.Count > 0)
            {
                ICommand c = context.undoStack.Pop();
                context.redoStack.Push(c);
                c.Undo(ref context);
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (context.redoStack.Count > 0)
            {
                ICommand c = context.redoStack.Pop();
                context.undoStack.Push(c);
                c.Execute(ref context);
            }
        }

        private void btnRect_Click(object sender, EventArgs e)
        {
            state = new RectangleState();
        }

        private void btnEllips_Click(object sender, EventArgs e)
        {
            state = new EllipsState();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            state = new SelectState();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            state = new MoveState();
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            state = new ResizeState();
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            List<Shape> selectedShapes = context.shapes.FindAll(shape => shape.IsSelected);
            if (selectedShapes.Count > 0)
            {
                ICommand c = new AddGroup(selectedShapes);
                context.undoStack.Push(c);
                context.redoStack.Clear();
                c.Execute(ref context);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\testPaintImage.txt";
            using (StreamWriter w = File.CreateText(path))
            {
                foreach (Shape s in context.shapes)
                {
                    w.Write(s.ToString());
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\testPaintImage.txt";
            List<Shape> tempShapes;
            using (StreamReader r = File.OpenText(path))
            {
                tempShapes = new List<Shape>();
                string line = r.ReadLine();
                if (line.StartsWith("group"))
                {
                    for (int i = 0; i < int.Parse(line.Split(' ')[1]); i++)
                    {
                        line = r.ReadLine();
                        string[] split = line.Split(' ');
                        if (split[0].Equals("rectangle"))
                        {
                            
                        }
                    }
                }
                else
                {
                    string[] split = line.Split(' ');
                }
            }
        }
    }
}