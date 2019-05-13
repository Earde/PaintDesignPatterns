using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintDesignPatterns.Commands;
using PaintDesignPatterns.Entity;

namespace PaintDesignPatterns.Action
{
    //Handling mouse for instantlt triggered button actions
    interface IAction
    {
        void OnClick(ref Context context);
    }
}
