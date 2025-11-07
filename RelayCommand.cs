using System;
using System.Windows.Input;

namespace Week6InventorySystem;

// Simple command so a Button can call a method
public class RelayCommand : ICommand
{
    public readonly Action _execute;

    public RelayCommand(Action execute)
    {
        _execute = execute;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _execute();
    }

    public event EventHandler? CanExecuteChanged;
}