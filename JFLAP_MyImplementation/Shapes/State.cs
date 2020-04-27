using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Media;
using JFLAP_MyApproach;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace JFLAP_MyApproach
{
    class State : IDrawable
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public int StateId { get; set; }
        public Ellipse StateObject { get; private set; }

        private TextLabel textLabel;
        public State(Point location, int _stateIndex)
        {
            // Save state location
            X = location.X;
            Y = location.Y;
            StateId = _stateIndex;
            // Create a new label for current state
            textLabel = new TextLabel(location, _stateIndex++);
            // Create a new ellipse
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

        public void Draw(Point location, Canvas canvas)
        {
            StateObject.Width = 46;
            StateObject.Height = 46;

            canvas.Children.Add(StateObject);
            canvas.Children.Add(textLabel.TextLabelObject);
        }
    }
}
