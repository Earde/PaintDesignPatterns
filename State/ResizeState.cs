using PaintDesignPatterns.Commands;
using PaintDesignPatterns.Entity;
using PaintDesignPatterns.Shapes;
using PaintDesignPatterns.Visitors;
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
            context.shapes.Accept(new ResizeVisitor(e.X - lastPoint.X, e.Y - lastPoint.Y));
            lastPoint = new Point(e.X, e.Y);
            context.drawPanel.Invalidate();
        }

        public void handleMouseUp(ref Context context, MouseEventArgs e)
        {
            context.drawPanel.Cursor = Cursors.Arrow;
            endPoint = new Point(e.X, e.Y);
            if (endPoint.X == initPoint.X && endPoint.Y == initPoint.Y) return;
            ShapeList shapes = new ShapeList(context.shapes.Get().FindAll(shape => shape.IsSelected));
            if (shapes.IsNotEmpty())
            {
                ICommand c = new AddResize(shapes, new Point(endPoint.X - initPoint.X, endPoint.Y - initPoint.Y));
                context.undoStack.Push(c);
                context.redoStack.Clear();
                c.Execute(ref context);
            }
        }
    }
}
