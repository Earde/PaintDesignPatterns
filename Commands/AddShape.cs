using PaintDesignPatterns.Entity;
using PaintDesignPatterns.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Commands
{
    class AddShape : ICommand
    {
        private CaptionShape shape;

        public AddShape(Shape shape)
        {
            this.shape = new CaptionShape(shape);
        }

        public void Execute(ref Context context)
        {
            context.shapes.Attach(shape);
            context.drawPanel.Invalidate();
        }

        public void Undo(ref Context context)
        {
            context.shapes.Detach(shape);
            context.drawPanel.Invalidate();
        }
    }
}
