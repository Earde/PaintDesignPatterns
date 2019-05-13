using PaintDesignPatterns.Commands;
using PaintDesignPatterns.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Action
{
    class UndoAction : IAction
    {
        public void OnClick(ref Context context)
        {
            if (context.undoStack.Count > 0)
            {
                ICommand c = context.undoStack.Pop();
                context.redoStack.Push(c);
                c.Undo(ref context);
            }
        }
    }
}
