using PaintDesignPatterns.Drawers;
using PaintDesignPatterns.Entity;
using PaintDesignPatterns.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Action
{
    class LoadAction : IAction
    {
        public void OnClick(ref Context context)
        {
            context.shapes.Clear();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\testPaintImage.txt";
            using (StreamReader r = File.OpenText(path))
            {
                string line;
                List<Ornament> ornaments = new List<Ornament>();
                while ((line = r.ReadLine()) != null)
                {
                    //load group shapes
                    if (line.StartsWith("group")) 
                    {
                        CaptionShape group = GetGroup(r, int.Parse(line.Split(' ')[1]), ornaments);
                        context.shapes.Attach(group);
                    }
                    //save ornaments for next shape
                    else if (line.StartsWith("ornament"))
                    {
                        ornaments.Add(GetOrnament(line));
                    }
                    //load non group shapes
                    else
                    {
                        CaptionShape s = GetShape(line, ornaments);
                        if (s != null)
                        {
                            context.shapes.Attach(s);
                            ornaments.Clear();
                        }
                    }
                }
            }
            context.redoStack.Clear();
            context.undoStack.Clear();
            context.drawPanel.Invalidate();
        }

        private CaptionShape GetGroup(StreamReader r, int count, List<Ornament> ornaments)
        {
            ShapeList tempShapes = new ShapeList();
            List<Ornament> newOrnaments = new List<Ornament>();
            for (int i = 0; i < count; i++) //loop group count
            {
                string groupLine = r.ReadLine();
                if (groupLine.StartsWith("ornament"))
                {
                    newOrnaments.Add(GetOrnament(groupLine));
                    i--; //ornament doesn't count as shape
                }
                else if (groupLine.StartsWith("group"))
                {
                    CaptionShape group = GetGroup(r, int.Parse(groupLine.Split(' ')[1]), newOrnaments);
                    if (group != null)
                    {
                        tempShapes.Attach(group);
                        newOrnaments.Clear();
                    }
                }
                else
                {
                    CaptionShape s = GetShape(groupLine, newOrnaments);
                    if (s != null)
                    {
                        tempShapes.Attach(s);
                        newOrnaments.Clear();
                    }
                }
            }
            CaptionShape result = new CaptionShape(new GroupShape(tempShapes));
            foreach (Ornament o in ornaments)
            {
                result.AddOrnament(o);
            }
            return result;
        }

        private CaptionShape GetShape(string line, List<Ornament> ornaments)
        {
            Shape shape = null;
            string[] split = line.Split(' '); //string split
            string[] numbersInString = new string[split.Length - 1]; //new array for storing integers minus first index aka name of shape
            Array.Copy(split, 1, numbersInString, 0, split.Length - 1); //copy string array to new string array without first index
            int[] numbers = Array.ConvertAll(numbersInString, int.Parse); //convert strings to integers
            if (split[0].Equals("rectangle"))
            {
                shape = new BasicShape(new Point(numbers[0], numbers[1]), new Point(numbers[0] + numbers[2], numbers[1] + numbers[3]), RectangleDrawer.Instance);
            }
            else if (split[0].Equals("ellipse"))
            {
                shape = new BasicShape(new Point(numbers[0], numbers[1]), new Point(numbers[0] + numbers[2], numbers[1] + numbers[3]), EllipsDrawer.Instance);
            }
            if (shape != null)
            {
                CaptionShape s = new CaptionShape(shape);
                foreach (Ornament ornament in ornaments)
                {
                    s.AddOrnament(ornament);
                }
                return s;
            }
            return null;
        }

        private Ornament GetOrnament(string line)
        {
            string[] split = line.Split(' '); //string split
            return new Ornament(split[2], split[1]);
        }
    }
}
