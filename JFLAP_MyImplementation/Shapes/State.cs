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
    class State : IDrawable
    {
        readonly Pen pen = null;
        public Ellipse StateObject { get; private set; }
        private int _stateIndex = 0;
        public State(Point location)
        {
            TextLabel label = new TextLabel(location, _stateIndex++);
            pen.Down(label);

            StateObject = new Ellipse
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

        public void Draw(Point locationX, Point locationY)
        {
            throw new NotImplementedException();
        }
    }
}
