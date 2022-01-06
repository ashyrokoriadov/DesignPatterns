using System;

namespace State.States
{
    class OperatorBreakState : IOperatorState
    {
        public string Name => StateName.BREAK;

        public bool Answer()
        {
            Console.WriteLine("Не могу ответить на звонок. В данный момент оператор на перерыве.");
            return false;
        }

        public bool End()
        {
            Console.WriteLine("Не могу закончить звонок. В данный момент оператор на перерыве.");
            return false;
        }

        public bool MakeBreak()
        {
            Console.WriteLine("Не могу перейти на перерыв во время перерыва. В данный момент оператор на перерыве.");
            return false;
        }

        public bool Reject()
        {
            Console.WriteLine("Не могу сбросить звонок. В данный момент оператор на перерыве.");
            return false;
        }

        public bool WrapUp()
        {
            Console.WriteLine("Не могу начать составление отчета о разговоре. В данный момент оператор на перерыве.");
            return false;
        }
    }
}
