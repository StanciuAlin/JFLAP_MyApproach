using System.Windows;
using System.Windows.Controls;

namespace JFLAP_MyApproach
{
    class Pen
    {
        private readonly Canvas _holder;
        public Pen(Canvas holder)
        {
            _holder = holder;
        }

        public void Down(IDrawable obj)
        {
            //if more shapes are added:
            //better use a switch-statement
            if (obj is State)
                _holder.Children.Add((obj as State).StateObject);
            if (obj is TextLabel)
                _holder.Children.Add((obj as TextLabel).TextLabelObject);
        }

        public void Draw(IDrawable obj, Point location)
        {
            obj.Draw(location);
        }
    }
}
