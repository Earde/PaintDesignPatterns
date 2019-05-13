using PaintDesignPatterns.Commands;
using PaintDesignPatterns.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Action
{
    class RedoAction : IAction
    {
        public void OnClick(ref Context context)
        {
            if (context.redoStack.Count > 0)
            {
                ICommand c = context.redoStack.Pop();
                context.undoStack.Push(c);
                c.Execute(ref context);
            }
        }
    }
}
