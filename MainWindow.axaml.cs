using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Week6InventorySystem;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    public void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}