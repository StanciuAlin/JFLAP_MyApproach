using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;


namespace JFLAP_MyCopy
{
    /// <summary>
    /// Interaction logic for FiniteAutomatonForm.xaml
    /// </summary>
    public partial class FiniteAutomatonForm : Window
    {
        private Point _start;
        private Point _end;

        public FiniteAutomatonForm()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        //private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    // Get the X & Y of where mouse is 1st clicked
        //    _start = e.GetPosition(this);
        //}

        //private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        //{
        //    // Update the X & Y as the mouse moves
        //    if (e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        _end = e.GetPosition(this);
        //    }
        //}

        //private void MyCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    // Draw the correct shape
        //    DrawEllipse();
        //}
        private void Draw(Point m)
        {
            canvasFiniteAutomaton.Children.Clear();

            int mX = (int)m.X;
            int mY = (int)m.Y;
            Ellipse el = new Ellipse
            {
                Width = 15,
                Height = 15
            };
            el.SetValue(Canvas.LeftProperty, (Double)mX);
            el.SetValue(Canvas.TopProperty, (Double)mY);
            el.Fill = Brushes.Black;

            canvasFiniteAutomaton.Children.Add(el);
            Canvas.SetZIndex(el, 10);
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Draw(e.GetPosition(canvasFiniteAutomaton));
            Draw(new Point(100, 100));
        }

        private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Draw(e.GetPosition(canvasFiniteAutomaton));
        }

        // Sets and draws ellipse after mouse is released
        private void DrawEllipse()
        {
            Ellipse newEllipse = new Ellipse()
            {
                Stroke = Brushes.Green,
                Fill = Brushes.Red,
                StrokeThickness = 4,
                Height = 10,
                Width = 10
            };

            // If the user the user tries to draw from
            // any direction then down and to the right
            // you'll get an error unless you use if
            // to change Left & TopProperty and Height
            // and Width accordingly

            if (_end.X >= _start.X)
            {
                // Defines the left part of the ellipse
                newEllipse.SetValue(Canvas.LeftProperty, _start.X);
                newEllipse.Width = _end.X - _start.X;
            }
            else
            {
                newEllipse.SetValue(Canvas.LeftProperty, _end.X);
                newEllipse.Width = _start.X - _end.X;
            }

            if (_end.Y >= _start.Y)
            {
                // Defines the top part of the ellipse
                newEllipse.SetValue(Canvas.TopProperty, _start.Y - 50);
                newEllipse.Height = _end.Y - _start.Y;
            }
            else
            {
                newEllipse.SetValue(Canvas.TopProperty, _end.Y - 50);
                newEllipse.Height = _start.Y - _end.Y;
            }

            canvasFiniteAutomaton.Children.Add(newEllipse);
        }

    }
}
