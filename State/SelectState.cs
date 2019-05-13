using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaintDesignPatterns.Commands;
using PaintDesignPatterns.Entity;
using PaintDesignPatterns.Shapes;

namespace PaintDesignPatterns.State
{
    class SelectState : IState
    {
        public void handleMouseDown(ref Context context, MouseEventArgs e)
        {
            context.tempShape = null;
            context.drawPanel.Cursor = Cursors.Arrow;
        }

        public void handleMouseMove(ref Context context, MouseEventArgs e)
        {

        }

        public void handleMouseUp(ref Context context, MouseEventArgs e)
        {
            context.drawPanel.Cursor = Cursors.Arrow;
            for (int i = context.shapes.Get().Count - 1; i >= 0; i--)
            {
                if (context.shapes.Get()[i].Select(e.X, e.Y))
                {
                    ICommand c = new AddSelect(context.shapes.Get()[i]);
                    context.undoStack.Push(c);
                    context.redoStack.Clear();
                    c.Execute(ref context);
                    return;
                }
            }
        }
    }
}
