using PaintDesignPatterns.Drawers;
using PaintDesignPatterns.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintDesignPatterns.Commands
{
    class AddRectangle : ICommand
    {
        private Shape shape;

        public AddRectangle(Shape shape)
        {
            this.shape = shape;
        }

        public void Execute(ref Context context)
        {
            context.shapes.Add(shape);
            context.drawPanel.Invalidate();
        }

        public void Undo(ref Context context)
        {
            context.shapes.Remove(shape);
            context.drawPanel.Invalidate();
        }
    }
}
