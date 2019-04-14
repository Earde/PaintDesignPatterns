using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Shapes
{
    class GroupShape : Shape
    {
        List<Shape> shapes;

        public GroupShape(List<Shape> shapeList)
        {
            shapes = shapeList;
        }

        public override void Draw(Graphics g)
        {
            foreach (Shape shape in shapes)
            {
                shape.Draw(g);
            }
            if (IsSelected)
            {
                Rectangle rect = GetCoordinates();
                g.DrawRectangle(hightlightPen, new Rectangle(rect.Left - 3, rect.Top - 3, rect.Width + 6, rect.Height + 6));
            }
        }

        public override Rectangle GetCoordinates()
        {
            int left = shapes.Min(shape => shape.GetCoordinates().Left);
            int top = shapes.Min(shape => shape.GetCoordinates().Top);
            int right = shapes.Max(shape => shape.GetCoordinates().Right);
            int bottom = shapes.Max(shape => shape.GetCoordinates().Bottom);
            return new Rectangle(left, top, right - left, bottom - top);
        }

        public override void Move(int dx, int dy)
        {
            foreach (Shape shape in shapes)
            {
                shape.Move(dx, dy);
            }
        }

        public override void Resize(int dx, int dy)
        {
            foreach (Shape shape in shapes)
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
            string result = string.Format("group {0}\r\n", shapes.Count.ToString());
            foreach (Shape s in shapes)
            {
                result += s.ToString();
            }
            return result;
        }
    }
}
