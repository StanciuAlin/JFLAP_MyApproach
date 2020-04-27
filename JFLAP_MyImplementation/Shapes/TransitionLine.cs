using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace JFLAP_MyApproach.Shapes
{

    class TransitionLine: IDrawable
    {
        public Line LineObject { get; private set; }
        public TextLabel TransitionTextLabel { get; private set; }
        public int TransitionId { get; set; }

        public TransitionLine(Point location)
        {
            LineObject = new Line
            {
                X1 = location.X,
                X2 = location.X,
                Y1 = location.Y - 52,
                Y2 = location.Y - 52,
                Stroke = System.Windows.Media.Brushes.LightSteelBlue,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                StrokeThickness = 2
            };
        }

        public void Draw(Point location, Canvas canvas)
        {
            LineObject.X2 = location.X;
            LineObject.Y2 = location.Y - 52;
        }

        public void Draw2(Point locationStart, Point locationEnd)
        {
            LineObject.X1 = locationStart.X;
            LineObject.Y1 = locationStart.Y;
            LineObject.X2 = locationEnd.X;
            LineObject.Y2 = locationEnd.Y;
        }
    }
}
