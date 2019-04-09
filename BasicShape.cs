using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns
{
    class BasicShape : Shape
    {
        private Drawer drawer;
        private Point startPoint;
        private Point endPoint;
        Pen pen;

        public BasicShape(Point start, Point end, Drawer drwr, Pen p)
        {
            startPoint = start;
            endPoint = end;
            drawer = drwr;
            pen = p;
        }

        public override void Draw(Graphics g)
        {
            drawer.Draw(g, pen, GetCoordinates());
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

        public override void Resize(int x, int y)
        {
            endPoint = new Point(x, y);
        }

        public override bool Select(int x, int y)
        {
            Rectangle rect = GetCoordinates();
            return rect.Left <= x && rect.Right >= x && rect.Top <= y && rect.Bottom >= y;
        }
    }
}
