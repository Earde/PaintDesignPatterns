using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintDesignPatterns.Commands;
using PaintDesignPatterns.Entity;
using PaintDesignPatterns.Shapes;

namespace PaintDesignPatterns.Action
{
    class CaptionAction : IAction
    {
        string text, position;

        public CaptionAction(string text, string position)
        {
            this.text = text;
            this.position = position;
        }

        public void OnClick(ref Context context)
        {
            CaptionShape shape = context.shapes.Get().Find(s => s.IsSelected);
            if (shape != null)
            {
                ICommand c = new AddCaption(shape, new Ornament(text, position));
                context.undoStack.Push(c);
                context.redoStack.Clear();
                c.Execute(ref context);
            }
        }
    }
}
