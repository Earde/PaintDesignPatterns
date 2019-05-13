using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintDesignPatterns.Entity;
using PaintDesignPatterns.Shapes;

namespace PaintDesignPatterns.Commands
{
    class AddSelect : ICommand
    {
        Shape shape;

        public AddSelect(Shape shape)
        {
            this.shape = shape;
        }

        public void Execute(ref Context context)
        {
            shape.IsSelected = !shape.IsSelected;
            context.drawPanel.Invalidate();
        }

        public void Undo(ref Context context)
        {
            shape.IsSelected = !shape.IsSelected;
            context.drawPanel.Invalidate();
        }
    }
}
