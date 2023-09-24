using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class SimpleStateMachine
    {
        private class StateTransition
        {
            private readonly EState _state;
            private readonly EEvent _event;

            public StateTransition(EState state, EEvent @event)
            {
                _state = state;
                _event = @event;
            }

            public override int GetHashCode()
            {
                return _state.GetHashCode() + _event.GetHashCode();
            }

            public override bool Equals(object? obj)
            {
                var other = obj as StateTransition;
                return other != null && this._state == other._state && this._event == other._event;
            }
        }

        private readonly Dictionary<StateTransition, EState> _transitions;
        public EState State { get; private set; }

        public SimpleStateMachine()
        {
            State = EState.Line;
            _transitions = new Dictionary<StateTransition, EState>
            {
                { new StateTransition(EState.Line, EEvent.DrawAsLine), EState.Line },
                { new StateTransition(EState.Spline, EEvent.DrawAsSpline), EState.Spline }
            };
        }

        public EState GetNext(EEvent @event)
        {
            var transition = new StateTransition(State, @event);
            if (!_transitions.TryGetValue(transition, out var nextState))
                throw new Exception("Invalid transition: " + State + " -> " + @event);
            return nextState;
        }

        public EState MoveNext(EEvent @event)
        {
            State = GetNext(@event);
            return State;
        }
    }
}
