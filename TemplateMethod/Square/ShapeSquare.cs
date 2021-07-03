using System;

namespace TemplateMethod.Square
{
    public abstract class ShapeSquare : ISquare
    {
        public double Square { get; protected set; }

        public bool IsValid { get; protected set; }

        public void Calculate()
        {
            Validate();

            if (IsValid)
            {
                CalculateShape();
                OutputResult();
            }
        }
        
        protected abstract void Validate();

        protected abstract void CalculateShape();

        protected virtual void OutputResult()
        {
            Console.WriteLine($"{GetType()}, square: {Square}");
        }
    }
}
