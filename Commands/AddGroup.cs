using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintDesignPatterns.Shapes;

namespace PaintDesignPatterns.Commands
{
    class AddGroup : ICommand
    {
        List<Shape> shapes;
        GroupShape group;

        public AddGroup(List<Shape> shapes)
        {
            this.shapes = shapes;
        }

        public void Execute(ref Context context)
        {
            group = new GroupShape(shapes);
            group.IsSelected = true;
            foreach (Shape s in shapes)
            {
                s.IsSelected = false;
                context.shapes.Remove(s);
            }
            context.shapes.Add(group);
            context.drawPanel.Invalidate();
        }

        public void Undo(ref Context context)
        {
            context.shapes.Remove(group);
            group = null;
            foreach (Shape s in shapes)
            {
                s.IsSelected = true;
                context.shapes.Add(s);
            }
            context.drawPanel.Invalidate();
        }
    }
}