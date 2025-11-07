using System;
using System.Collections.ObjectModel;

namespace Week6InventorySystem;

public class PrintableObservableCollection<T> : ObservableCollection<T>
{
    public override string ToString()
    {
        return string.Join(Environment.NewLine, this);
    }
}