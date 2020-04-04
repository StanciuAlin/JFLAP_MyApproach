using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Media;
using JFLAP_MyApproach;
using System.Windows.Shapes;

namespace JFLAP_MyApproach
{
    class Circle : IDrawable
    {
        public Ellipse CircleObject { get; private set; }

        public Circle(Point location)
        {
            CircleObject = new Ellipse
            {
                Width = 46,
                Height = 46,
                Stroke = Brushes.Firebrick,
                StrokeThickness = 2,
                Fill = Brushes.LemonChiffon,
                Margin = new Thickness(location.X - 20, location.Y - 80, 0, 0),
            };

        }

        public void Draw(Point location)
        {
            
        }
        
    }
}
