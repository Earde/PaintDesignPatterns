using PaintDesignPatterns.Entity;
using PaintDesignPatterns.Shapes;
using PaintDesignPatterns.Visitors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Action
{
    class SaveAction : IAction
    {
        public void OnClick(ref Context context)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\testPaintImage.txt";
            using (StreamWriter w = File.CreateText(path))
            {
                context.shapes.Accept(new SaveVisitor(w));
            }
        }
    }
}