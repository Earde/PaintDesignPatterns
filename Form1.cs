using PaintDesignPatterns.Action;
using PaintDesignPatterns.Commands;
using PaintDesignPatterns.Drawers;
using PaintDesignPatterns.Entity;
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
        IAction action = null;

        Context context;

        public Form1()
        {
            InitializeComponent();
            positionText.SelectedIndex = 0;
            context = new Context(drawPanel);
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
            foreach (Shape shape in context.shapes.Get())
            {
                shape.Draw(e.Graphics);
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

        private void btnUndo_Click(object sender, EventArgs e)
        {
            action = new UndoAction();
            action.OnClick(ref context);
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            action = new RedoAction();
            action.OnClick(ref context);
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            action = new MakeGroupAction();
            action.OnClick(ref context);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            action = new SaveAction();
            action.OnClick(ref context);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            action = new LoadAction();
            action.OnClick(ref context);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            action = new CaptionAction(captionText.Text, positionText.Text);
            action.OnClick(ref context);
        }
    }
}