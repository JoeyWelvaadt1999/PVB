using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class StateMachine<T>
    {
        private Dictionary<T, State> _states = new Dictionary<T, State>();
        private State _currentState;

        public void Update()
        {
            if (_currentState != null)
            {
                _currentState.Act();
                _currentState.Reason();
            }
        }

        public void SetState(T key)
        {
            if (!_states.ContainsKey(key))
            {
                return;
            }

            if (_currentState != null)
            {
                _currentState.Leave();
            }

            _currentState = _states[key];
            _currentState.Enter();
        }

        public void AddState(T key, State value)
        {
            if (!_states.ContainsKey(key))
            {
                _states.Add(key, value);
            }
        }
    }
}
