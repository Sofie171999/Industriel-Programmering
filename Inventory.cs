namespace InventorySystem;

public class Inventory
{
    private Dictionary<Item, int> stock = new Dictionary<Item, int>();
    
    public void AddItem(Item item, int quantity)
    {
        stock[item] = quantity;
    }
    
    public IEnumerable<Item> LowStockItems()
    {
        return stock
            .Where(entry => entry.Value < 5)
            .Select(entry => entry.Key);
    }
}