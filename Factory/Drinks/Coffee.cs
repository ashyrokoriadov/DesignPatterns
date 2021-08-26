using System;

namespace Factory.Drinks
{
    class Coffee : IDrink
    {
        public override string ToString() => "Кофе";

        public void Prepare()
        {
            Console.WriteLine($"Подготовка: {ToString()}.");
        }

        public void Serve()
        {
            Console.WriteLine($"Подача: {ToString()}.");
        }
    }
}
