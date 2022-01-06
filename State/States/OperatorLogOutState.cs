using System;

namespace State.States
{
    public class OperatorLogOutState : IOperatorState
    {
        public string Name => StateName.LOGOUT;

        public bool Answer()
        {
            Console.WriteLine("Не могу ответить звонок. В данный момент оператор вне системы.");
            return false;
        }

        public bool End()
        {
            Console.WriteLine("Не могу закончить звонок. В данный момент оператор вне системы.");
            return false;
        }

        public bool MakeBreak()
        {
            Console.WriteLine("Не могу сделать перерыв. В данный момент оператор вне системы");
            return false;
        }

        public bool Reject()
        {
            Console.WriteLine("Не могу сбросить звонок. В данный момент оператор вне системы");
            return false;
        }

        public bool WrapUp()
        {
            Console.WriteLine("Не могу начать составление отчета о разговоре. В данный момент оператор вне системы.");
            return false;
        }
    }
}
