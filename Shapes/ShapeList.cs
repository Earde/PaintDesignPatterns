using PaintDesignPatterns.Shapes;
using PaintDesignPatterns.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Shapes
{
    class ShapeList
    {
        private List<CaptionShape> shapes;

        public ShapeList()
        {
            shapes = new List<CaptionShape>();
        }

        public ShapeList(List<CaptionShape> shapes)
        {
            this.shapes = shapes;
        }

        public void Attach(CaptionShape shape)
        {
            shapes.Add(shape);
        }

        public void Detach(CaptionShape shape)
        {
            shapes.Remove(shape);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Shape shape in shapes)
            {
                shape.Accept(visitor);
            }
        }

        public List<CaptionShape> Get()
        {
            return shapes;
        }

        public void Clear()
        {
            shapes.Clear();
        }

        public bool IsNotEmpty()
        {
            return shapes != null && shapes.Count > 0;
        }
    }
}
