using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace JFLAP_MyApproach
{
    class Pen
    {
        public Pen(Canvas holder)
        {
            _holder = holder;
        }

        private readonly Canvas _holder;

        public void Down(IDrawable obj)
        {
            //if more shapes are added:
            //better use a switch-statement
            if (obj is Circle)
                _holder.Children.Add((obj as Circle).DrawCircle);
            //if (obj is MyLine)
            //    _holder.Children.Add((obj as MyLine).Line);
        }

        public void Draw(IDrawable obj, Point location)
        {
            obj.Draw(location);
        }
    }
}
