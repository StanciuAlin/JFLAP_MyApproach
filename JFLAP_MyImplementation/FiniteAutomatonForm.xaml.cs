using JFLAP_MyApproach;
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

        string stateIndex;
        int currentStateIndex;
        string stateIndexChar = "q";

        public FiniteAutomatonForm()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void canvasFiniteAutomatonDrawShape_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Get the X & Y of where mouse is 1st clicked
            
        }

        private void canvasFiniteAutomatonDrawShape_MouseMove(object sender, MouseEventArgs e)
        {
            // Update the X & Y as the mouse moves
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _start = e.GetPosition(this);
            }
        }

        private void canvasFiniteAutomatonDrawShape_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Draw the correct shape
            //DrawEllipse();
            //Draw(_start);
        }

        private void canvasFiniteAutomatonDrawNewState_LeftButtonDown(object sender, MouseEventArgs e)
        {
            _start = e.GetPosition(this);
            
        }
        private void canvasFiniteAutomaton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DrawCircle(_start);
        }
        private void DrawCircle(Point m)
        {
            Circle circle = new Circle(_start);
            Label label = new Label
            {
                Width = 30,
                Height = 30,
                Background = Brushes.LemonChiffon,
                Margin = new Thickness(_start.X - 12, _start.Y - 72, 0, 0),
                Content = Convert.ToString(stateIndexChar + currentStateIndex++),
            };

            canvasFiniteAutomaton.Children.Add(circle.CircleObject);
            canvasFiniteAutomaton.Children.Add(label);
            
        }

    }
}
