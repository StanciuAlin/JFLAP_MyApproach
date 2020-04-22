using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JFLAP_MyApproach
{
    class TextLabel: IDrawable
    {
        public Label TextLabelObject { get; private set; }

        private string _textLabel = "";
        private int _stateIndex = 0;

        public TextLabel(Point coordinationLabel, int stateIndex)
        {
            this._stateIndex = stateIndex;

            TextLabelObject = new Label
            {
                Width = 30,
                Height = 30,
                Background = Brushes.LemonChiffon,
                Margin = new Thickness(coordinationLabel.X - 12, coordinationLabel.Y - 72, 0, 0),
                Content = Convert.ToString("q" + _stateIndex)
            };
        }

        public TextLabel(string textLabel, Point coordinationLabel)
        {
            this._textLabel = textLabel;
            TextLabelObject = new Label
            {
                Width = 30,
                Height = 30,
                Background = Brushes.LemonChiffon,
                Margin = new Thickness(coordinationLabel.X - 12, coordinationLabel.Y - 72, 0, 0),
                Content = textLabel
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
