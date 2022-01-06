using System;

namespace State.States
{
    public class OperatorFreeState : IOperatorState
    {
        public string Name => StateName.FREE;

        public bool Answer()
        {
            Console.WriteLine("Отвечаю на телефонный звонок.");
            return true;
        }

        public bool End()
        {
            Console.WriteLine("Не могу закончить звонок. В данный момент оператор не ведет разговор.");
            return false;
        }

        public bool MakeBreak()
        {
            Console.WriteLine("Делаю перерыв в работе.");
            return true;
        }

        public bool Reject()
        {
            Console.WriteLine("Сбрасываю звонок приходящий звонок абонента.");
            return true;
        }

        public bool WrapUp()
        {
            Console.WriteLine("Не могу начать составление отчета о разговоре. В данный момент оператор не ведет разговор.");
            return true;
        }
    }
}
