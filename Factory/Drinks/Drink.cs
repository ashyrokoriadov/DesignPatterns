using Factory.Ingridients.BaseComponents;
using Factory.Ingridients.IngridientsFactory;
using Factory.Ingridients.Liquids;
using Factory.Ingridients.Sweeteners;
using System;

namespace Factory.Drinks
{
    class Drink : IDrink
    {
        private IDrinkBaseComponent BaseComponent { get; set; }

        private ILiquid Liquid { get; set; }

        private ISweetener Sweetener { get; set; }


        public Drink(IDrinkIngridientsFactory ingridientsFactory)
        {
            BaseComponent = ingridientsFactory.OrderBaseComponent();
            Liquid = ingridientsFactory.OrderLiquid();
            Sweetener = ingridientsFactory.OrderSweetener();
        }

        public void Prepare()
        {
            Console.WriteLine($"Подготовка - смешиваю 3 компонента: {BaseComponent}, {Liquid} и {Sweetener}.");
        }

        public void Serve()
        {
            Console.WriteLine("Подача: напиток готов!");
        }
    }
}
