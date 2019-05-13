using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintDesignPatterns.Entity;
using PaintDesignPatterns.Shapes;

namespace PaintDesignPatterns.Commands
{
    class AddCaption : ICommand
    {
        CaptionShape shape;
        Ornament ornament;

        public AddCaption(CaptionShape shape, Ornament ornament)
        {
            this.shape = shape;
            this.ornament = ornament;
        }

        public void Execute(ref Context context)
        {
            shape.AddOrnament(ornament);
            context.drawPanel.Invalidate();
        }

        public void Undo(ref Context context)
        {
            shape.RemoveOrnament(ornament);
            context.drawPanel.Invalidate();
        }
    }
}
