namespace TemplateMethod.Square
{
    public class TriangleSquare : ShapeSquare
    {
        public double TriangleSide { get; init; }

        public double TriangleHeight { get; init; }     

        /// <summary>
        /// Создаёт новый экземляр класса для расчета площади треугольника через сторону и высоту.
        /// </summary>
        /// <param name="a">Сторона треугольника.</param>
        /// <param name="h">Высота опущенная на сторону треугольника.</param>
        public TriangleSquare(double a, double h)
        {
            TriangleSide = a;
            TriangleHeight = h;
        }

        protected override void Validate()
        {
            IsValid = TriangleSide >= 0 || TriangleHeight >= 0;
        }

        protected override void CalculateShape()
        {
            // формула площади треугольника через сторону и высоту
            // https://skysmart.ru/articles/mathematic/ploshad-treugolnika

            Square = 0.5 * TriangleSide * TriangleHeight;
        }  
    }
}
