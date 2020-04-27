using JFLAP_MyApproach.Shapes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace JFLAP_MyApproach
{
    class DFA
    {
        public List<State> _states { get; set; }
        public List<TransitionLine> _transitionLines { get; set; }
        // un tuplu cu starea de start si starea de final
        public List<Tuple<State, State>> a;
        public DFA()
        {
            _states = new List<State>(10);
            _transitionLines = new List<TransitionLine>(10);
        }

        public void AddState(State stateToAdd)
        {
            //Check whether given state already exists in DFA or the given state has same ID or name as some other state in DFA 
            foreach (State existingState in _states)
            {
                if (existingState.StateId == stateToAdd.StateId)
                {
                    //Console.WriteLine("ERROR: Cannot add state to the dfa with same id!");
                    return;
                }

            }

            // Add the state
            _states.Add(stateToAdd);

        }//AddState

        public void RemoveState(State StateToRemove)
        {
            // Check whether the state to be removed is current state.

            // Loops through dfa's states and compares their id to given state's id. If match is found, state is removed from dfa.
            foreach (State existingState in _states)
            {
                if (existingState.StateId == StateToRemove.StateId)
                {
                    _states.Remove(StateToRemove);
                    return;
                }
            }
            //If state was not found, print error
            MessageBox.Show("The state was not found.", "Error", MessageBoxButton.OK);
        }
    }
}
