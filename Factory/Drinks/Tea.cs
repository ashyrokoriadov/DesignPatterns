using System;

namespace Factory.Drinks
{
    class Tea : IDrink
    {
        public override string ToString() => "Чай";
        
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
