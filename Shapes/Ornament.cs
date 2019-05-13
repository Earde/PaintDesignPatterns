using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Shapes
{
    class Ornament
    {
        public string text;
        public string position;

        public Ornament(string text, string position)
        {
            this.text = text;
            this.position = position;
        }

        public override string ToString()
        {
            return "ornament " + this.position + " " + this.text + "\r\n";
        }
    }
}
