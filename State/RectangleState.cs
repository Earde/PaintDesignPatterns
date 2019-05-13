using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaintDesignPatterns.Commands;
using PaintDesignPatterns.Drawers;
using PaintDesignPatterns.Entity;
using PaintDesignPatterns.Shapes;

namespace PaintDesignPatterns.State
{
    class RectangleState : IState
    {
        Point initPoint;
        Point lastPoint;

        public void handleMouseDown(ref Context context, MouseEventArgs e)
        {
            context.drawPanel.Cursor = Cursors.Arrow;
            initPoint = new Point(e.X, e.Y);
            lastPoint = new Point(e.X, e.Y);
            context.tempShape = new BasicShape(initPoint, initPoint, RectangleDrawer.Instance);
        }

        public void handleMouseMove(ref Context context, MouseEventArgs e)
        {
            context.tempShape.Resize(e.X - lastPoint.X, e.Y - lastPoint.Y);
            lastPoint = new Point(e.X, e.Y);
            context.drawPanel.Invalidate();
        }

        public void handleMouseUp(ref Context context, MouseEventArgs e)
        {
            context.drawPanel.Cursor = Cursors.Arrow;
            Rectangle rect = context.tempShape.GetCoordinates();
            if (rect.Width == 0 || rect.Height == 0) return; //don't add empty shape
            ICommand c = new AddShape(context.tempShape);
            context.undoStack.Push(c);
            context.redoStack.Clear();
            c.Execute(ref context);
        }
    }
}
