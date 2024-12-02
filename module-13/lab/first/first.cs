public class Inventory
{
    private Dictionary<string, int> stock = new Dictionary<string, int>
    {
        { "ItemA", 10 },
        { "ItemB", 5 },
        { "ItemC", 0 }
    };

    public bool CheckAvailability(string itemName)
    {
        if (stock.ContainsKey(itemName) && stock[itemName] > 0)
        {
            Console.WriteLine($"Товар {itemName} в наличии. Количество: {stock[itemName]}.");
            return true;
        }
        else
        {
            Console.WriteLine($"Товар {itemName} отсутствует на складе.");
            return false;
        }
    }
}
