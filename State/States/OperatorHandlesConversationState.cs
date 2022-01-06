using System;

namespace State.States
{
    public class OperatorHandlesConversationState : IOperatorState
    {
        public string Name => StateName.HANDLES_CONVERSATION;

        public bool Answer()
        {
            Console.WriteLine("Не могу ответить на звонок. В данный момент оператор ведет разговор.");
            return false;
        }

        public bool End()
        {
            Console.WriteLine("Заканчиваю обслуживание.");
            return true;
        }

        public bool MakeBreak()
        {
            Console.WriteLine("Не могу перейти на перерыв во время обслуживания клиента. Оператор ведет разговор.");
            return false;
        }

        public bool Reject()
        {
            Console.WriteLine("Не могу сбросить звонок во время активного разговора.");
            return false;
        }

        public bool WrapUp()
        {
            Console.WriteLine("Не могу начать составление отчета о разговоре. В данный момент оператор ведет разговор.");
            return false;
        }
    }
}
