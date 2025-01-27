# Data Binding Tutorial

This tutorial explains how to use data binding in Avalonia UI to link your application's data with its UI.

## Contents

- [Overview](#overview)
- [Setup](#setup)
- [Code Examples](#code-examples)
- [Next Steps](#next-steps)

---

## Overview

Data binding is essential for creating dynamic, interactive user interfaces. This tutorial will show you how to:
- Create a ViewModel with properties.
- Bind data to XAML UI elements.
- Use best practices for Avalonia UI projects.

---

## Setup

1. Create a new Avalonia UI project.
2. Add the `ReactiveUI` NuGet package:
   ```bash
   dotnet add package ReactiveUI
   ```
3. Set up the project structure as shown below.

---

## Code Examples

### **1. ViewModel**
The `ViewModel` holds the data and logic for your application. Here’s an example:

```csharp
using ReactiveUI;

public class MainViewModel : ReactiveObject
{
    private string _name;
    private string _selectedOption;

    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public string SelectedOption
    {
        get => _selectedOption;
        set => this.RaiseAndSetIfChanged(ref _selectedOption, value);
    }

    public string[] Options { get; } = { "Option 1", "Option 2", "Option 3" };
}
```

### **2. XAML**
Bind the ViewModel properties to UI elements in XAML:
```xml
<Window xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:vm="using:YourNamespace.ViewModels"
        Title="Data Binding Example"
        Width="400"
        Height="300">
    <Window.DataContext>
        <vm:MainViewModel />
    </Window.DataContext>
    <StackPanel Margin="10">
        <TextBox PlaceholderText="Enter your name" Text="{Binding Name}" />
        <ComboBox Items="{Binding Options}" SelectedItem="{Binding SelectedOption}" />
        <TextBlock Text="{Binding Name}" Margin="0,10,0,0" />
        <TextBlock Text="{Binding SelectedOption}" />
    </StackPanel>
</Window>
```

### **3. Application Setup**
Set up the application entry point to link the ViewModel with the View:

```csharp
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}
```

---

## Next Steps

1. Add validation to your ViewModel for user input.
2. Explore advanced data binding techniques, such as multi-binding.
3. Combine data binding with commands to handle user actions.

---

## Related Topics

- [Dynamic Widgets with Avalonia UI](../README.md)
- [Avalonia UI Documentation](https://docs.avaloniaui.net/)
