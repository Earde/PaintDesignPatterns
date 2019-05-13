using PaintDesignPatterns.Commands;
using PaintDesignPatterns.Entity;
using PaintDesignPatterns.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintDesignPatterns.State
{
    //Handling mouse for drawing panel
    interface IState
    {
        void handleMouseDown(ref Context context, MouseEventArgs e);

        void handleMouseMove(ref Context context, MouseEventArgs e);

        void handleMouseUp(ref Context context, MouseEventArgs e);
    }
}
