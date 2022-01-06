using System;

namespace State.States
{
    public class OperatorWrapUpState : IOperatorState
    {
        public string Name => StateName.WRAP_UP;

        public bool Answer()
        {
            Console.WriteLine("Не могу ответить на звонок. В данный момент оператор подготавливает отчет.");
            return false;
        }

        public bool End()
        {
            Console.WriteLine("Не могу закончить звонок. Оператор не ведет разговор. В данный момент оператор подготавливает отчет.");
            return false;
        }

        public bool MakeBreak()
        {
            Console.WriteLine("Не могу перейти на перерыв во время подготовки отчета. Оператор подготавливает отчет.");
            return false;
        }

        public bool Reject()
        {
            Console.WriteLine("Не могу сбросить звонок. Оператор не ведет разговор. В данный момент оператор подготавливает отчет.");
            return false;
        }

        public bool WrapUp()
        {
            Console.WriteLine("Не могу начать составление отчета о разговоре во время подготовки другого отчета. Оператор подготавливает отчет.");
            return false;
        }
    }
}
