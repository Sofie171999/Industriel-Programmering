using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Week6InventorySystem;

public class MainWindowViewModel
{
    public readonly ItemSorterRobot robot = new();

    public MainWindowViewModel()
    {
        OrderBook = new OrderBook();
        Inventory = new Inventory();

        ProcessNextOrderCommand = new RelayCommand(ProcessNextOrderAsync);

        RunGridDemoCommand = new RelayCommand(RunGridDemo);

        AddExampleData();
        RefreshLowStock();
    }

    public OrderBook OrderBook { get; set; }
    public Inventory Inventory { get; set; }

    public RelayCommand RunGridDemoCommand { get; set; }
    public RelayCommand ProcessNextOrderCommand { get; set; }


    public ObservableCollection<Item> LowStock { get; } = new();
    public string StatusMessages { get; set; } = ""; // bound to the UI

    // Called when you click the Process button.
    // Sends a URScript per order line (with a small delay) and only then moves the order.
    public async void ProcessNextOrderAsync()
    {
        if (OrderBook.QueuedOrders.Count == 0)
        {
            StatusMessages += "No queued orders." + Environment.NewLine;
            return;
        }

        var order = OrderBook.QueuedOrders[0]; // look at next order
        StatusMessages += "Processing order..." + Environment.NewLine;

        foreach (var orderLine in order.OrderLines)
            // Repeat for the quantity of that line
            for (var i = 0; i < orderLine.Quantity; i++)
            {
                StatusMessages += $"Picking up {orderLine.Item.Name} (slot {orderLine.Item.InventoryLocation})" +
                                  Environment.NewLine;
                robot.PickUp(orderLine.Item.InventoryLocation);

                // about 9.5–10s per movement like the teacher suggested
                await Task.Delay(9500);
            }

        // After the robot is done, mark the order processed (moves it to the right list + adds revenue)
        OrderBook.ProcessNextOrder();
        StatusMessages += "Order complete." + Environment.NewLine;
    }

    public void AddExampleData()
    {
        // Items
        var item1 = new UnitItem { Name = "M3 screw", PricePerUnit = 1m, InventoryLocation = 1u, Weight = 0.1m };
        var item2 = new UnitItem { Name = "M3 nut", PricePerUnit = 1.5m, InventoryLocation = 2u, Weight = 0.05m };
        var item3 = new UnitItem { Name = "Pen", PricePerUnit = 1m, InventoryLocation = 3u, Weight = 0.02m };

        // Order lines
        var line1 = new OrderLine { Item = item1, Quantity = 1 };
        var line2 = new OrderLine { Item = item2, Quantity = 2 };
        var line3 = new OrderLine { Item = item3, Quantity = 1 };

        // Orders
        var order1 = new Order { Time = DateTime.Now.AddDays(-2), OrderLines = { line1, line2, line3 } };
        var order2 = new Order { Time = DateTime.Now, OrderLines = { line2 } };

        // Customers and queue
        var customer1 = new Customer { Name = "Ramanda" };
        var customer2 = new Customer { Name = "Totoro" };
        customer1.CreateOrder(OrderBook, order1);
        customer2.CreateOrder(OrderBook, order2);

        // Inventory quantities (for LowStock demo)
        Inventory.AddItem(item1, 10);
        Inventory.AddItem(item2, 3); // low
        Inventory.AddItem(item3, 2); // low
    }

    public void RefreshLowStock()
    {
        LowStock.Clear();
        foreach (var item in Inventory.LowStockItems())
            LowStock.Add(item);
    }

    public void RunGridDemo()
    {
        StatusMessages += "Running grid demo a→b→c→d..." + Environment.NewLine;
        robot.SendDemoPathAtoBtoCtoD();
    }
}