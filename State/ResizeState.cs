using PaintDesignPatterns.Commands;
using PaintDesignPatterns.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintDesignPatterns.State
{
    class ResizeState : IState
    {
        Point initPoint;
        Point lastPoint;
        Point endPoint;

        public void handleMouseDown(ref Context context, MouseEventArgs e)
        {
            context.drawPanel.Cursor = Cursors.SizeAll;
            context.tempShape = null;
            initPoint = new Point(e.X, e.Y);
            lastPoint = new Point(e.X, e.Y);
        }

        public void handleMouseMove(ref Context context, MouseEventArgs e)
        {
            foreach (Shape s in context.shapes)
            {
                if (s.IsSelected)
                {
                    s.Resize(e.X - lastPoint.X, e.Y - lastPoint.Y);
                }
            }
            lastPoint = new Point(e.X, e.Y);
            context.drawPanel.Invalidate();
        }

        public void handleMouseUp(ref Context context, MouseEventArgs e)
        {
            context.drawPanel.Cursor = Cursors.Arrow;
            endPoint = new Point(e.X, e.Y);
            if (endPoint.X == initPoint.X && endPoint.Y == initPoint.Y) return;
            List<Shape> shapes = context.shapes.FindAll(shape => shape.IsSelected);
            if (shapes.Count > 0)
            {
                foreach (Shape s in shapes)
                {
                    s.Resize(initPoint.X - endPoint.X, initPoint.Y -  endPoint.Y);
                }
                ICommand c = new AddResize(shapes, new Point(endPoint.X - initPoint.X, endPoint.Y - initPoint.Y));
                context.undoStack.Push(c);
                context.redoStack.Clear();
                c.Execute(ref context);
            } 
        }
    }
}
