using System;

namespace TemplateMethod.Square
{
    public class CircleSquare : ShapeSquare
    {
        public double Radius { get; init; }

        /// <summary>
        /// Создаёт новый экземляр класса для расчета площади окружности.
        /// </summary>
        /// <param name="r">Радиус окружжности.</param>
        public CircleSquare(double r)
        {
            Radius = r;
        }

        protected override void Validate()
        {
            IsValid = Radius >= 0;
        }

        protected override void CalculateShape()
        {
            // формула площади окружности
            // https://skysmart.ru/articles/mathematic/ploshad-kruga

            Square = Math.PI * Radius * Radius;
        }
    }
}
