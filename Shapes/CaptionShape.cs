using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintDesignPatterns.Visitors;

namespace PaintDesignPatterns.Shapes
{
    class CaptionShape : Shape
    {
        protected Shape shape;
        public List<Ornament> ornaments = new List<Ornament>();
        private Font font = new Font("Times New Roman", 12.0f);

        private StringFormat verticalFormat, horizontalFormat;

        public CaptionShape(Shape shape)
        {
            this.shape = shape;
            verticalFormat = new StringFormat();
            verticalFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            horizontalFormat = new StringFormat();
            horizontalFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void AddOrnament(Ornament ornament)
        {
            int index = ornaments.FindIndex(o => o.position.Equals(ornament.position));
            if (index != -1)
            {
                ornaments[index] = ornament;
            } else
            {
                ornaments.Add(ornament);
            }
        }

        public void RemoveOrnament(Ornament ornament)
        {
            ornaments.Remove(ornament);
        }

        public override void Draw(Graphics g)
        {
            shape.IsSelected = this.IsSelected;
            shape.Draw(g);
            foreach (Ornament ornament in ornaments)
            {
                Rectangle rect = shape.GetCoordinates();
                SizeF textSize = g.MeasureString(ornament.text, font);
                switch (ornament.position)
                {
                    case "Top":
                        g.DrawString(ornament.text, font, Brushes.Black, rect.Left + rect.Width / 2 + textSize.Width / 2, rect.Top - textSize.Height - 5, horizontalFormat);
                        break;
                    case "Bottom":
                        g.DrawString(ornament.text, font, Brushes.Black, rect.Left + rect.Width / 2 + textSize.Width / 2, rect.Top + rect.Height + 5, horizontalFormat);
                        break;
                    case "Left":
                        g.DrawString(ornament.text, font, Brushes.Black, rect.Left - textSize.Height - 5, rect.Top + rect.Height / 2 - textSize.Width / 2, verticalFormat);
                        break;
                    case "Right":
                        g.DrawString(ornament.text, font, Brushes.Black, rect.Right + 5, rect.Top + rect.Height / 2 - textSize.Width / 2, verticalFormat);
                        break;
                    default:
                        break;
                }
            }
        }

        public override Rectangle GetCoordinates()
        {
            return shape.GetCoordinates();
        }

        public override void Move(int dx, int dy)
        {
            shape.Move(dx, dy);
        }

        public override void Resize(int dx, int dy)
        {
            shape.Resize(dx, dy);
        }

        public override string ToString()
        {
            string output = "";
            foreach (Ornament ornament in ornaments)
            {
                output += ornament.ToString();
            }
            return output + shape.ToString();
        }
    }
}
