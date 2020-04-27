using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JFLAP_MyApproach
{
    class TextLabel: IDrawable
    {
        public Label TextLabelObject { get; private set; }

        public TextLabel(Point coordinationLabel, int stateIndex)
        {
            TextLabelObject = new Label
            {
                Width = 30,
                Height = 30,
                Background = Brushes.LemonChiffon,
                Margin = new Thickness(coordinationLabel.X - 12, coordinationLabel.Y - 72, 0, 0),
                Content = Convert.ToString("q" + stateIndex)
            };
        }

        public TextLabel(string textLabel, Point coordinationLabel)
        {
            TextLabelObject = new Label
            {
                Width = 30,
                Height = 30,
                Background = Brushes.LemonChiffon,
                Margin = new Thickness(coordinationLabel.X - 12, coordinationLabel.Y - 72, 0, 0),
                Content = textLabel
            };
        }

        public void Draw(Point location, Canvas canvas)
        {
            throw new NotImplementedException();
        }
    }
}
