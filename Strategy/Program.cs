using Strategy.BusinessLogic;
using Strategy.Constants;
using Strategy.LoggingStartegies;
using System;

namespace Strategy
{
    class Program
    {
        static string _loggingStrategyType;
        static ILoggingStrategy _loggingStrategy;
        static Calculator _calculator;

        static void Main(string[] args)
        {
            ReadParameters(args);
            DefineStrategy();
            InitializeCalculator();
            PerformCalculations();

            Console.ReadKey();
        }

        static void ReadParameters(string[] args)
        {
            _loggingStrategyType = args.Length == 1 ? args[0] : LoggingStrategies.CONSOLE;
        }

        static void DefineStrategy()
        {
            switch (_loggingStrategyType)
            {
                case LoggingStrategies.DB:
                    _loggingStrategy = new DbLoggerStrategy();
                    break;
                case LoggingStrategies.FILE:
                    _loggingStrategy = new FileLoggerStrategy();
                    break;
                default:
                    _loggingStrategy = new ConsoleLoggerStrategy();
                    break;
            }
        }

        static void InitializeCalculator()
        {
            _calculator = new Calculator(_loggingStrategy);
        }

        static void PerformCalculations()
        {
            _calculator.Add(9, 3);
            _calculator.Subtract(9, 3);
            _calculator.Multiply(9, 3);
            _calculator.Divide(9, 3);
        }
    }
}
