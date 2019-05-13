using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintDesignPatterns.Entity;
using PaintDesignPatterns.Shapes;
using PaintDesignPatterns.Visitors;

namespace PaintDesignPatterns.Commands
{
    class AddMove : ICommand
    {
        private ShapeList movedShapes;
        private Point distance;

        public AddMove(ShapeList movedShapes, Point distance)
        {
            this.movedShapes = movedShapes;
            this.distance = distance;
            movedShapes.Accept(new MoveVisitor(-distance.X, -distance.Y));
        }

        public void Execute(ref Context context)
        {
            movedShapes.Accept(new MoveVisitor(distance.X, distance.Y));
            context.drawPanel.Invalidate();
        }

        public void Undo(ref Context context)
        {
            movedShapes.Accept(new MoveVisitor(-distance.X, -distance.Y));
            context.drawPanel.Invalidate();
        }
    }
}
