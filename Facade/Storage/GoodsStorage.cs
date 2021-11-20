using System;

namespace Facade.Storage
{
    public class GoodsStorage : IStorage
    {
        public bool TakeItem(string itemName, int quantity)
        {
            Console.WriteLine($"Был получен товар: {itemName} в количестве {quantity} штук.");
            return true;
        }

        public bool AddItem(string itemName, int quantity)
        {
            Console.WriteLine($"Был добавлен товар: {itemName} в количестве {quantity} штук.");
            return true;
        }

        public bool ItemExist(string itemName)
        {
            Console.WriteLine($"Товар {itemName} есть на складе.");
            return true;
        }
    }
}
