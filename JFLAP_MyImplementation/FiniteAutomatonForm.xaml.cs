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
        private Point _startCoordinationState = new Point(0, 0);

        private Point _startCoordinationLine = new Point(0, 0);
        private Point _endCoordinationLine = new Point(0, 0);

        #region Button variables pressed/not pressed
        // varibles for New state button which check if it is pressed or not
        private bool _isPressedSelectBtn = false;
        private int _counterBtnSelect = 0;

        // varibles for New state button which check if it is pressed or not
        private bool _isPressedNewStateBtn = false;
        private int _counterBtnState = 0;

        // varibles for New state button which check if it is pressed or not
        private bool _isPressedTransitionBtn = false;
        private int _counterBtnTransition = 0;

        // varibles for New state button which check if it is pressed or not
        private bool _isPressedDeleteBtn = false;
        private int _counterBtnDelete = 0;

        // varibles for New state button which check if it is pressed or not
        private bool _isPressedAddLabelBtn = false;
        private int _counterBtnAddLabel = 0;

        // varibles for New state button which check if it is pressed or not
        private bool _isPressedUndoBtn = false;
        private int _counterBtnUndo = 0;

        // varibles for New state button which check if it is pressed or not
        private bool _isPressedRedoBtn = false;
        private int _counterBtnRedo = 0;
        #endregion

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


        #region Canvas
        private void canvasFiniteAutomatonDrawShape_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Get the X & Y of where mouse is 1st clicked
            _startCoordinationLine = e.GetPosition(this);
        }

        private void canvasFiniteAutomatonDrawShape_MouseMove(object sender, MouseEventArgs e)
        {
            // Update the X & Y as the mouse moves
            //if (e.LeftButton == MouseButtonState.Pressed && _isPressedNewStateBtn)
            //{
            //    _startCoordinationState = e.GetPosition(this);
            //}

            //if (e.LeftButton == MouseButtonState.Pressed && _isPressedTransitionBtn)
            //{

            //}

        }

        private void canvasFiniteAutomatonDrawShape_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Draw the correct shape
            _endCoordinationLine = e.GetPosition(this);
            if (_isPressedTransitionBtn)
            {
                DrawLine();
            }
        }

        private void canvasFiniteAutomatonDrawNewState_LeftButtonDown(object sender, MouseEventArgs e)
        {
            if (_isPressedNewStateBtn)
            {
                _startCoordinationState = e.GetPosition(this);
            }

            //if (_isPressedTransitionBtn)
            //{
            //    _startCoordinationLine = e.GetPosition(this);
            //}

            //DrawCircle(e.GetPosition(this));
        }
        private void canvasFiniteAutomaton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_isPressedNewStateBtn)
            {
                DrawCircle(_startCoordinationState);
            }


        }
        #endregion

        #region Draw shape

        private void DrawLine()
        {
            // Add a Line Element
            Line line = new Line();
            line.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            line.X1 = _startCoordinationLine.X;
            line.X2 = _endCoordinationLine.X;

            line.Y1 = _startCoordinationLine.Y - 52;
            line.Y2 = _endCoordinationLine.Y - 52;
            line.HorizontalAlignment = HorizontalAlignment.Left;
            line.VerticalAlignment = VerticalAlignment.Center;
            line.StrokeThickness = 2;
            canvasFiniteAutomaton.Children.Add(line);
        }
        private void DrawCircle(Point m)
        {
            Circle circle = new Circle(_startCoordinationState);
            Label label = new Label
            {
                Width = 30,
                Height = 30,
                Background = Brushes.LemonChiffon,
                Margin = new Thickness(_startCoordinationState.X - 12, _startCoordinationState.Y - 72, 0, 0),
                Content = Convert.ToString(stateIndexChar + currentStateIndex++),
            };

            canvasFiniteAutomaton.Children.Add(circle.CircleObject);
            canvasFiniteAutomaton.Children.Add(label);
        }
        #endregion


        #region Press button (pressed/not pressed)
        private void DrawNewStateFiniteAutomaton_Click(object sender, EventArgs e)
        {
            _counterBtnState++;
            _isPressedNewStateBtn = true;
            btn_DrawStateCanvasFiniteAutomaton.Opacity = 0.5;

            if (_isPressedNewStateBtn && (_counterBtnState % 2 == 0))
            {
                _isPressedNewStateBtn = false;
                btn_DrawStateCanvasFiniteAutomaton.Opacity = 1;
            }

        }

        private void DrawTransitionLineBetweenStatesFiniteAutomaton_Click(object sender, EventArgs e)
        {
            _counterBtnTransition++;
            _isPressedTransitionBtn = true;

            btn_DrawTransitionCanvasFiniteAutomaton.Opacity = 0.5;

            if (_isPressedTransitionBtn && (_counterBtnTransition % 2 == 0))
            {
                _isPressedTransitionBtn = false;
                btn_DrawTransitionCanvasFiniteAutomaton.Opacity = 1;
            }
        }

        private void SelectShapeFiniteAutomaton_Click(object sender, EventArgs e)
        {
            _counterBtnSelect++;
            _isPressedSelectBtn = true;

            btn_SelectCanvasFiniteAutomaton.Opacity = 0.5;

            if (_isPressedSelectBtn && (_counterBtnSelect % 2 == 0))
            {
                _isPressedSelectBtn = false;
                btn_SelectCanvasFiniteAutomaton.Opacity = 1;
            }
        }

        private void DeleteShapeFiniteAutomaton_Click(object sender, EventArgs e)
        {
            _counterBtnDelete++;
            _isPressedDeleteBtn = true;

            btn_DeleteCanvasFiniteAutomaton.Opacity = 0.5;

            if (_isPressedDeleteBtn && (_counterBtnDelete % 2 == 0))
            {
                _isPressedDeleteBtn = false;
                btn_DeleteCanvasFiniteAutomaton.Opacity = 1;
            }
        }

        private void AddLabelOnTransitionFiniteAutomaton_Click(object sender, EventArgs e)
        {
            _counterBtnAddLabel++;
            _isPressedAddLabelBtn = true;

            btn_AddLabelCanvasFiniteAutomaton.Opacity = 0.5;

            if (_isPressedAddLabelBtn && (_counterBtnAddLabel % 2 == 0))
            {
                _isPressedAddLabelBtn = false;
                btn_AddLabelCanvasFiniteAutomaton.Opacity = 1;
            }
        }

        private void UndoOperationFiniteAutomaton_Click(object sender, EventArgs e)
        {
            _counterBtnUndo++;
            _isPressedUndoBtn = true;

            btn_UndoCanvasFiniteAutomaton.Opacity = 0.5;

            if (_isPressedUndoBtn && (_counterBtnUndo % 2 == 0))
            {
                _isPressedUndoBtn = false;
                btn_UndoCanvasFiniteAutomaton.Opacity = 1;
            }
        }

        private void RedoOperationFiniteAutomaton_Click(object sender, EventArgs e)
        {
            _counterBtnRedo++;
            _isPressedRedoBtn = true;

            btn_RedoCanvasFiniteAutomaton.Opacity = 0.5;

            if (_isPressedRedoBtn && (_counterBtnRedo % 2 == 0))
            {
                _isPressedRedoBtn = false;
                btn_RedoCanvasFiniteAutomaton.Opacity = 1;
            }
        }
        #endregion

    }
}
