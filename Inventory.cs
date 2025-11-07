using System.Collections.Generic;

namespace Week6InventorySystem;

// Tracks how many of each Item you have
public class Inventory
{
    public Dictionary<Item, int> Stock { get; set; } = new();

    public void AddItem(Item item, int amount)
    {
        if (Stock.ContainsKey(item)) Stock[item] += amount;
        else Stock[item] = amount;
    }

    public void RemoveItem(Item item, int amount)
    {
        if (!Stock.ContainsKey(item)) return;

        Stock[item] -= amount;
        if (Stock[item] < 0) Stock[item] = 0;
    }

    // Low = less than 5 (as your teacher suggested)
    public List<Item> LowStockItems()
    {
        var result = new List<Item>();
        foreach (var kv in Stock)
            if (kv.Value < 5)
                result.Add(kv.Key);
        return result;
    }
}