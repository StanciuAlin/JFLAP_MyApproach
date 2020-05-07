using JFLAP_MyApproach;
using JFLAP_MyApproach.Shapes;
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
        const int radius = 23;

        private Point _startCoordinationState = new Point(0, 0);

        private Point _startCoordinationLine = new Point(0, 0);
        private Point _endCoordinationLine = new Point(0, 0);

        private int _stateIndex = 0;
        private TransitionLine line = null;
        private bool _isMouseButtonPressed = false;

        DFA dFA = new DFA();

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

        public FiniteAutomatonForm()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }


        #region Canvas
        private void canvasFiniteAutomatonDrawShape_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Get the X & Y of where mouse is 1st clicked
           
            if (!_isPressedDeleteBtn)
            {
                if (_isPressedTransitionBtn)
                {
                    _startCoordinationLine = e.GetPosition(this);
                    foreach (State state in dFA._states)
                    {
                        if (Math.Pow(state.X - _endCoordinationLine.X, 2) + Math.Pow(state.Y - _endCoordinationLine.Y, 2) < Math.Pow(radius, 2))
                        {
                            _startCoordinationLine.X = state.X;
                            _startCoordinationLine.Y = state.Y;
                        }
                    }
                    line = new TransitionLine(_startCoordinationLine);

                    canvasFiniteAutomaton.Children.Add(line.LineObject);
                    
                    _isMouseButtonPressed = true;
                }
                else if (_isPressedNewStateBtn)
                {
                    _startCoordinationState = e.GetPosition(this);
                }
            }
            else
            {
                Point point = e.GetPosition((UIElement)sender);
                HitTestResult result = VisualTreeHelper.HitTest(canvasFiniteAutomaton, point);
                if (result != null)
                {
                    canvasFiniteAutomaton.Children.Remove(result.VisualHit as UIElement);
                }
            }

        }

        private void canvasFiniteAutomatonDrawShape_MouseMove(object sender, MouseEventArgs e)
        {
            _endCoordinationLine = e.GetPosition(this);
            if (_isPressedTransitionBtn)
            {
                if (_isMouseButtonPressed)
                {
                    line.Draw(_endCoordinationLine, canvasFiniteAutomaton);
                }
            }
        }

        private void canvasFiniteAutomatonDrawShape_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_isPressedNewStateBtn)
            {
                State state = new State(_startCoordinationState, _stateIndex++);
                dFA.AddState(state);
                state.Draw(_startCoordinationState, canvasFiniteAutomaton);
            }

            if (_isPressedTransitionBtn)
            {
                foreach (State state in dFA._states)
                {
                    if (Math.Pow(state.X - _endCoordinationLine.X, 2) + Math.Pow(state.Y - _endCoordinationLine.Y, 2) < Math.Pow(radius, 2))
                    {
                        _endCoordinationLine.X = state.X;
                        _endCoordinationLine.Y = state.Y;

                        double deltaY = _endCoordinationLine.Y - _startCoordinationLine.Y;
                        double deltaX = _endCoordinationLine.X - _startCoordinationLine.X;

                        double len = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
                        double r = radius / len;

                        double y1 = _startCoordinationLine.Y + deltaY * r;
                        double y2 = _endCoordinationLine.Y - deltaY * r;

                        double x1 = _startCoordinationLine.X + deltaX * r;
                        double x2 = _endCoordinationLine.X - deltaX * r;

                        _startCoordinationLine.X = x1;
                        _startCoordinationLine.Y = y1 - 55;

                        _endCoordinationLine.X = x2;
                        _endCoordinationLine.Y = y2 - 55;
                        ////noi am facut tangenta aici
                        //_endCoordinationLine.Y -= 31;
                        //_endCoordinationLine.X -= 31;
                        //double sideX = _endCoordinationLine.X - state.X;
                        //double sideY = _endCoordinationLine.Y - state.Y;
                        //double len = Math.Sqrt(Math.Pow(sideX, 2) + Math.Pow(sideY, 2));

                        //double r = radius / len;
                        ////double alpha = Math.Atan2(sideX, sideY) * (Math.PI / 180F);
                        ////_endCoordinationLine.X = state.X + radius * Math.Sin(alpha * Math.PI / 180F);
                        ////_endCoordinationLine.Y = state.Y + radius * Math.Cos(alpha * Math.PI / 180F);

                        //_endCoordinationLine.X = state.X + sideX * r;
                        //_endCoordinationLine.Y = state.Y + sideY * r;
                        ////_endCoordinationLine.Y = state.Y + (radius / len) * sideY;

                        ////result.Y = (int)Math.Round(centerPoint.Y + distance * Math.Sin(angle));
                        ////result.X = (int)Math.Round(centerPoint.X + distance * Math.Cos(angle));


                        //line.Draw(_endCoordinationLine, canvasFiniteAutomaton);
                        Point _endCoordinationLineArrowUp = new Point();
                        Point _endCoordinationLineArrowBottom = new Point();
                        Point _startCoordinationLineArrow = _endCoordinationLine;

                        _endCoordinationLineArrowUp.X = _endCoordinationLine.X - 10 * Math.Cos(30);
                        _endCoordinationLineArrowUp.Y = _endCoordinationLine.Y - 10 * Math.Sin(30);

                        _endCoordinationLineArrowBottom.X = _endCoordinationLine.X + 10 * Math.Cos(30);
                        _endCoordinationLineArrowBottom.Y = _endCoordinationLine.X + 10 * Math.Sin(30);


                        line.Draw2(_startCoordinationLine, _endCoordinationLine);
                        
                    }
                }
                // Draw the correct shape
                _isMouseButtonPressed = false;
            }


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
