using PaintDesignPatterns.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Commands
{
    class AddEllips : ICommand
    {
        private Shape shape;

        public AddEllips(Shape shape)
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
