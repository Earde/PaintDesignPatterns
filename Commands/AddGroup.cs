using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintDesignPatterns.Entity;
using PaintDesignPatterns.Shapes;

namespace PaintDesignPatterns.Commands
{
    class AddGroup : ICommand
    {
        ShapeList shapes;
        CaptionShape group;

        public AddGroup(ShapeList shapes)
        {
            this.shapes = shapes;
            group = new CaptionShape(new GroupShape(shapes));
        }

        public void Execute(ref Context context)
        {
            group.IsSelected = true;
            foreach (CaptionShape s in shapes.Get())
            {
                s.IsSelected = false;
                context.shapes.Detach(s);
            }
            context.shapes.Attach(group);
            context.drawPanel.Invalidate();
        }

        public void Undo(ref Context context)
        {
            context.shapes.Detach(group);
            foreach (CaptionShape s in shapes.Get())
            {
                s.IsSelected = true;
                context.shapes.Attach(s);
            }
            context.drawPanel.Invalidate();
        }
    }
}