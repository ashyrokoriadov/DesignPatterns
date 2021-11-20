namespace Facade.Storage
{
    public interface IStorage
    {
        bool TakeItem(string itemName, int quantity);

        bool AddItem(string itemName, int quantity);

        bool ItemExist(string itemName);
    }
}
