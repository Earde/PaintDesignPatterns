using PaintDesignPatterns.Commands;
using PaintDesignPatterns.Entity;
using PaintDesignPatterns.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Action
{
    class MakeGroupAction : IAction
    {
        public void OnClick(ref Context context)
        {
            ShapeList selectedShapes = new ShapeList(context.shapes.Get().FindAll(shape => shape.IsSelected));
            if (selectedShapes.IsNotEmpty())
            {
                ICommand c = new AddGroup(selectedShapes);
                context.undoStack.Push(c);
                context.redoStack.Clear();
                c.Execute(ref context);
            }
        }
    }
}
