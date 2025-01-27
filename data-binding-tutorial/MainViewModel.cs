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
