using State.States;
using System;
using System.Collections.Generic;
using System.Linq;

namespace State.Operators
{
    public class Operator : IOperator
    {
        private readonly IEnumerable<IOperatorState> _possibleStates;
        private IOperatorState _activeState;

        public Operator(IOperatorStateCollection states, string initialState)
        {
            _possibleStates = states.AsEnumerable();
            SetInitialState(initialState);
        }

        private void SetInitialState(string initialState)
        {
            _activeState = _possibleStates.Single(state => state.Name == initialState);
            Console.WriteLine($"Оператор перешел в состояние {_activeState.Name}");
        }

        public void AnswerCall()
        {
            var result = _activeState.Answer();

            if (result)
                SetInitialState(StateName.HANDLES_CONVERSATION);
            else
                Console.WriteLine($"Не могу ответить на звонок. Операция не обслуживается в текущем состоянии: {_activeState.Name}");
        }

        public void RejectCall()
        {
            var result = _activeState.Reject();

            if (result)
                SetInitialState(StateName.FREE);
            else
                Console.WriteLine($"Не могу сбросить звонок. Операция не обслуживается в текущем состоянии: {_activeState.Name}");
        }

        public void EndCall()
        {
            var result = _activeState.End();

            if (result)
                SetInitialState(StateName.WRAP_UP);
            else
                Console.WriteLine($"Не могу закончить звонок. Операция не обслуживается в текущем состоянии: {_activeState.Name}");
        }

        public void EndCreatingReport()
        {
            if (_activeState.Name == StateName.WRAP_UP)
                SetInitialState(StateName.FREE);
            else
                Console.WriteLine($"Не могу закончить подготовку отчета. Операция не обслуживается в текущем состоянии: {_activeState.Name}");
        }

        public void MakeBreak()
        {
            var result = _activeState.MakeBreak();

            if (result)
                SetInitialState(StateName.BREAK);
            else
                Console.WriteLine($"Не могу начать перерыв. Операция не обслуживается в текущем состоянии: {_activeState.Name}");
        }

        public void EndBreak()
        {
            if (_activeState.Name == StateName.BREAK)
                SetInitialState(StateName.FREE);
            else
                Console.WriteLine($"Не могу закончить перерыв. Операция не обслуживается в текущем состоянии: {_activeState.Name}");
        }

        public void LogIn()
        {
            if (_activeState.Name == StateName.LOGOUT)
                SetInitialState(StateName.FREE);
            else
                Console.WriteLine($"Не могу войти в систему. Операция не обслуживается в текущем состоянии: {_activeState.Name}");
        }

        public void LogOut()
        {
            SetInitialState(StateName.LOGOUT);
        }
    }
}
