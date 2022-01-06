using Autofac;
using Autofac.Features.AttributeFilters;
using State.Operators;
using State.States;
using System;

namespace State
{
    class Program
    {
        static IOperator _operator;
        static void Main(string[] args)
        {
            RegisterDependencies();
            DisplayMenu();

            using (var scope = Container.BeginLifetimeScope())
            {
                _operator = scope.Resolve<IOperator>();

                while (true)
                {
                    var key = Console.ReadKey().Key;
                    Console.WriteLine();

                    if (key == ConsoleKey.Q)
                        break;

                    HandleUserInput(key);
                }
            }

            Console.ReadKey();
        }

        private static void HandleUserInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A:
                    _operator.AnswerCall();
                    break;
                case ConsoleKey.R:
                    _operator.RejectCall();
                    break;
                case ConsoleKey.E:
                    _operator.EndCall();
                    break;
                case ConsoleKey.W:
                    _operator.EndCreatingReport();
                    break;
                case ConsoleKey.B:
                    _operator.MakeBreak();
                    break;
                case ConsoleKey.F:
                    _operator.EndBreak();
                    break;
                case ConsoleKey.Y:
                    _operator.LogIn();
                    break;
                case ConsoleKey.T:
                    _operator.LogOut();
                    break;
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Работа оператора:");
            Console.WriteLine("\t - нажмите А чтобы ответить на звонок");
            Console.WriteLine("\t - нажмите R чтобы сбросить звонок");
            Console.WriteLine("\t - нажмите E чтобы закончить");
            Console.WriteLine("\t - нажмите W чтобы закончить создание отчета");
            Console.WriteLine("\t - нажмите B чтобы выйти на перерыв");
            Console.WriteLine("\t - нажмите F чтобы закончить перерыв");
            Console.WriteLine("\t - нажмите Y чтобы войти в систему");
            Console.WriteLine("\t - нажмите T чтобы выйти из системы");
            Console.WriteLine("");
            Console.WriteLine("Нажмите Q чтобы выйти из приложения");
            Console.WriteLine("");
        }

        private static void RegisterDependencies()
        {
            Builder.RegisterType<OperatorBreakState>().Keyed<IOperatorState>(StateName.BREAK);
            Builder.RegisterType<OperatorWrapUpState>().Keyed<IOperatorState>(StateName.WRAP_UP);
            Builder.RegisterType<OperatorHandlesConversationState>().Keyed<IOperatorState>(StateName.HANDLES_CONVERSATION);
            Builder.RegisterType<OperatorFreeState>().Keyed<IOperatorState>(StateName.FREE);
            Builder.RegisterType<OperatorLogOutState>().Keyed<IOperatorState>(StateName.LOGOUT);
            Builder.RegisterType<DefaultOperatorStateCollection>().As<IOperatorStateCollection>().WithAttributeFiltering();
            Builder.RegisterType<Operator>().As<IOperator>().WithParameter("initialState", StateName.FREE); ;
        }

        private static IContainer _container;
        public static IContainer Container => _container ?? (_container = Builder.Build());

        private static ContainerBuilder _builder;
        public static ContainerBuilder Builder => _builder ?? (_builder = new ContainerBuilder());
    }
}
