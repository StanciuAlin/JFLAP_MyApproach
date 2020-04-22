using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Shapes;

namespace JFLAP_MyApproach.Shapes
{

    class TransitionLine: IDrawable
    {

        public Line LineObject { get; private set; }
        public TextLabel TransitionTextLabel { get; private set; }
        public TransitionLine(Point locationX, Point locationY)
        {
            LineObject = new Line
            {
                X1 = locationX.X,
                X2 = locationY.X,
                Y1 = locationX.Y - 52,
                Y2 = locationY.Y - 52,
                Stroke = System.Windows.Media.Brushes.LightSteelBlue,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                StrokeThickness = 2
            };
        }

        public void Draw(Point location)
        {
            throw new NotImplementedException();
        }

        public void Draw(Point locationX, Point locationY)
        {
            throw new NotImplementedException();
        }
    }
}
