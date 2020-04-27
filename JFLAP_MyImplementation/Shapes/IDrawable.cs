using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace JFLAP_MyApproach
{
    interface IDrawable
    {
        void Draw(Point location, Canvas canvas);
    }
}
