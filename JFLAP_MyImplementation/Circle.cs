using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace JFLAP_MyApproach
{
    class Circle : IDrawable
    {
        public Ellipse DrawCircle { get; private set; }

        public List<Ellipse> circles = new List<Ellipse>();

        public Circle(Point location, List<Ellipse> myCircles)
        {
            DrawCircle = new Ellipse
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Fill = Brushes.Green,
                Margin = new Thickness(location.X, location.Y, 0, 0),
            };
            myCircles = circles;
        }

        public void Draw(Point location)
        {
            if (DrawCircle != null)
            {
                //Circle.Width = location.X - Circle.Margin.Left;
                //Circle.Height = location.Y - Circle.Margin.Top;
                DrawCircle.Width = 40;
                DrawCircle.Height = 40;
                circles.Add(DrawCircle);
            }
        }
    }
}
