using PaintDesignPatterns.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Commands
{
    interface ICommand
    {
        void Execute(ref Context context);
        void Undo(ref Context context);
    }
}
