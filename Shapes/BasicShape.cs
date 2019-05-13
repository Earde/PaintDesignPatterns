using PaintDesignPatterns.Drawers;
using PaintDesignPatterns.Visitors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Shapes
{
    class BasicShape : Shape
    {
        private Drawer drawer;
        private Point startPoint;
        private Point endPoint;

        public BasicShape(Point start, Point end, Drawer drwr)
        {
            startPoint = start;
            endPoint = end;
            drawer = drwr;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void Draw(Graphics g)
        {
            drawer.Draw(g, pen, GetCoordinates(), highlightPen, IsSelected);
        }

        public override Rectangle GetCoordinates()
        {
            Point leftTop = new Point(startPoint.X < endPoint.X ? startPoint.X : endPoint.X, startPoint.Y < endPoint.Y ? startPoint.Y : endPoint.Y);
            Point rightBottom = new Point(startPoint.X > endPoint.X ? startPoint.X : endPoint.X, startPoint.Y > endPoint.Y ? startPoint.Y : endPoint.Y);
            return new Rectangle(leftTop.X, leftTop.Y, rightBottom.X - leftTop.X, rightBottom.Y - leftTop.Y);
        }

        public override void Move(int dx, int dy)
        {
            startPoint.X += dx;
            endPoint.X += dx;
            startPoint.Y += dy;
            endPoint.Y += dy;
        }

        public override void Resize(int dx, int dy)
        {
            endPoint.X += dx;
            endPoint.Y += dy;
        }

        public override string ToString()
        {
            Rectangle rect = GetCoordinates();
            return string.Format("{0} {1} {2} {3} {4}\r\n", drawer.ToString(), rect.Left.ToString(), rect.Top.ToString(), rect.Width.ToString(), rect.Height.ToString());
        }
    }
}
