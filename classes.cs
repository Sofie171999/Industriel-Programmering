// Classes.cs (replace your existing classes with this)

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Week6InventorySystem;

// ---------- Items ----------
public class Item
{
    public string Name { get; set; } = "";

    public decimal PricePerUnit { get; set; }
    -public int InventoryLocation { get; set; }
    +public uint InventoryLocation { get; set; } // <- required by the new task
}

public class UnitItem : Item
{
    public decimal Weight { get; set; }
}

public class BulkItem : Item
{
    public string MeasurementUnit { get; set; } = "pcs";
}

// ---------- Orders ----------
public class OrderLine
{
    public Item Item { get; set; }
    public int Quantity { get; set; }

    public override string ToString()
    {
        return $"{Item.Name} x {Quantity}";
    }
}

public class Order
{
    public DateTime Time { get; set; } = DateTime.Now;

    // Use printable collection so the DataGrid shows readable text
    public PrintableObservableCollection<OrderLine> OrderLines { get; set; } = new();

    public decimal TotalPrice => OrderLines.Sum(line => line.Item.PricePerUnit * line.Quantity);

    public override string ToString()
    {
        return $"{Time:g} • {OrderLines.Count} lines • {TotalPrice:C}";
    }
}

// ---------- Customers ----------
public class Customer
{
    public string Name { get; set; } = "";
    public List<Order> Orders { get; set; } = new();


    public void CreateOrder(OrderBook orderBook, Order order)
    {
        Orders.Add(order);
        orderBook.QueueOrder(order);
    }
}

// ---------- OrderBook (binds to the GUI) ----------
public class OrderBook : INotifyPropertyChanged
{
    private decimal _totalRevenue;
    public ObservableCollection<Order> QueuedOrders { get; } = new();
    public ObservableCollection<Order> ProcessedOrders { get; } = new();

    public decimal TotalRevenue
    {
        get => _totalRevenue;
        private set
        {
            _totalRevenue = value;
            OnPropertyChanged(nameof(TotalRevenue));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void QueueOrder(Order order)
    {
        QueuedOrders.Add(order);
    }

    public void ProcessNextOrder()
    {
        if (QueuedOrders.Count == 0) return;

        var next = QueuedOrders[0];
        QueuedOrders.RemoveAt(0);
        ProcessedOrders.Add(next);
        TotalRevenue += next.TotalPrice;
    }

    private void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

public class Robot
{
    public const int urscriptPort = 30002, dashboardPort = 29999;
    public string IpAddress = "localhost";


    public void SendString(int port, string message)
    {
        using var client = new TcpClient(IpAddress, port);
        using var stream = client.GetStream();
        stream.Write(Encoding.ASCII.GetBytes(message));
    }

    public void SendUrscript(string urscript)
    {
        SendString(dashboardPort, "brake release\n");
        SendString(urscriptPort, urscript);
    }
}