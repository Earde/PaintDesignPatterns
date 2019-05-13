using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintDesignPatterns.Visitors;

namespace PaintDesignPatterns.Shapes
{
    class GroupShape : Shape
    {
        ShapeList shapes;

        public GroupShape(ShapeList shapeList)
        {
            shapes = shapeList;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void Draw(Graphics g)
        {
            foreach (Shape shape in shapes.Get())
            {
                shape.Draw(g);
            }
            if (IsSelected)
            {
                Rectangle rect = GetCoordinates();
                g.DrawRectangle(highlightPen, new Rectangle(rect.Left - 3, rect.Top - 3, rect.Width + 6, rect.Height + 6));
            }
        }

        public override Rectangle GetCoordinates()
        {
            List<CaptionShape> shapeList = shapes.Get();
            int left = shapeList.Min(shape => shape.GetCoordinates().Left);
            int top = shapeList.Min(shape => shape.GetCoordinates().Top);
            int right = shapeList.Max(shape => shape.GetCoordinates().Right);
            int bottom = shapeList.Max(shape => shape.GetCoordinates().Bottom);
            return new Rectangle(left, top, right - left, bottom - top);
        }

        public override void Move(int dx, int dy)
        {
            foreach (Shape shape in shapes.Get())
            {
                shape.Move(dx, dy);
            }
        }

        public override void Resize(int dx, int dy)
        {
            foreach (Shape shape in shapes.Get())
            {
                shape.Resize(dx, dy);
            }
            /*
            Rectangle rect = GetCoordinates();
            double factorX = dx != 0 ? (double)dx / (double)rect.Width : 0;
            double factorY = dy != 0 ? (double)dy / (double)rect.Height : 0;
            foreach (Shape shape in shapes)
            {
                Rectangle shapeRect = shape.GetCoordinates();
                shape.Resize(shapeRect.Left + (int)((double)shapeRect.Width * factorX), shapeRect.Top + (int)((double)shapeRect.Height * factorY));
            }
            */
        }

        public override string ToString()
        {
            string result = string.Format("group {0}\r\n", shapes.Get().Count);
            foreach (Shape s in shapes.Get())
            {
                result += s.ToString();
            }
            return result;
        }
    }
}
