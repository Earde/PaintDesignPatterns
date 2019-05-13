using PaintDesignPatterns.Commands;
using PaintDesignPatterns.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintDesignPatterns.Entity
{
    class Context
    {
        //Drawing panel
        public Panel drawPanel;
        //Action stacks
        public Stack<ICommand> undoStack = new Stack<ICommand>();
        public Stack<ICommand> redoStack = new Stack<ICommand>();
        //Drawn shapes and Temporary shape for action visualization
        public Shape tempShape = null;
        public ShapeList shapes = new ShapeList();

        public Context(Panel panel)
        {
            drawPanel = panel;
        }
    }
}
