using PaintDesignPatterns.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Visitors
{
    interface IVisitor
    {
        void Visit(Shape shape);
    }
}
