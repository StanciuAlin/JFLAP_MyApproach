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
        private Point _startCoordinationState = new Point(0, 0);

        private Point _startCoordinationLine = new Point(0, 0);
        private Point _endCoordinationLine = new Point(0, 0);

        
        private bool _isMouseButtonPressed = false;

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
            Environment.Exit(0);
        }


        #region Canvas
        private void canvasFiniteAutomatonDrawShape_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Get the X & Y of where mouse is 1st clicked

            
            
        }

        private void canvasFiniteAutomatonDrawShape_MouseMove(object sender, MouseEventArgs e)
        {
            _endCoordinationLine = e.GetPosition(this);
            if (_isPressedTransitionBtn)
            {
                if (_isMouseButtonPressed)
                {
                    DrawLine();
                }
            }
        }

        private void canvasFiniteAutomatonDrawShape_MouseUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void canvasFiniteAutomatonDrawNewState_LeftButtonDown(object sender, MouseEventArgs e)
        {
            if (!_isPressedDeleteBtn)
            {
                if (_isPressedTransitionBtn)
                {
                    _startCoordinationLine = e.GetPosition(this);
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
        private void canvasFiniteAutomaton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_isPressedNewStateBtn)
            {
                DrawCircle(_startCoordinationState);
            }

            if (_isPressedTransitionBtn)
            {
                // Draw the correct shape
                _isMouseButtonPressed = false;
            }

        }
        #endregion

        #region Draw shape

        private void DrawLine()
        {
            // Add a Line Element
            TransitionLine line = new TransitionLine(_startCoordinationLine, _endCoordinationLine);
            canvasFiniteAutomaton.Children.Add(line.LineObject);
        }
        private void DrawCircle(Point m)
        {
            State circle = new State(_startCoordinationState);
            canvasFiniteAutomaton.Children.Add(circle.StateObject);
            
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
