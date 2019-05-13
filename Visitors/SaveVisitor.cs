using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintDesignPatterns.Shapes;

namespace PaintDesignPatterns.Visitors
{
    class SaveVisitor : IVisitor
    {
        StreamWriter writer;

        public SaveVisitor(StreamWriter writer)
        {
            this.writer = writer;
        }

        public void Visit(Shape shape)
        {
            writer.Write(shape.ToString());
        }
    }
}
