using Strategy.LoggingStartegies;
using System;

namespace Strategy.BusinessLogic
{
    public class Calculator
    {
        private ILoggingStrategy _logger;

        public Calculator(ILoggingStrategy loggingStrategy)
        {
            _logger = loggingStrategy ?? throw new ArgumentNullException(nameof(loggingStrategy));
        }

        public decimal Add(decimal x, decimal y)
        {
            var result = x + y;
            _logger.Log($"{x} + {y} = {result}");
            return result;
        }

        public decimal Subtract(decimal x, decimal y)
        {
            var result = x - y;
            _logger.Log($"{x} - {y} = {result}");
            return result;
        }

        public decimal Multiply(decimal x, decimal y)
        {
            var result = x * y;
            _logger.Log($"{x} * {y} = {result}");
            return result;
        }

        public decimal Divide(decimal x, decimal y)
        {
            try
            {
                var result = x / y;
                _logger.Log($"{x} / {y} = {result}");
                return result;
            }
            catch (DivideByZeroException ex)
            {
                _logger.Log(ex.Message);
                return 0;
            }           
        }
    }
}
