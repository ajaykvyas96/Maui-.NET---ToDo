using System.Diagnostics;
using ToDo.MauiClient.DataServices;
using ToDo.MauiClient.Models;

namespace ToDo.MauiClient.Pages;

[QueryProperty(nameof(ToDo), "ToDo")]
public partial class ManageToDoPage : ContentPage
{
    private readonly IRestDataService _dataService;
    ToDoItem _toDo;
    bool _isNew;
    public ToDoItem ToDo
    {
        get => _toDo;
        set
        {
            _isNew = IsNew(value);
            _toDo = value;
            OnPropertyChanged();
        }
    }
    public ManageToDoPage(IRestDataService dataService)
    {
        InitializeComponent();
        _dataService = dataService;
        BindingContext = this;
    }

    bool IsNew(ToDoItem toDo)
    {
        if (toDo.Id == 0)
            return true;
        return false;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (_isNew)
        {
            Debug.WriteLine("Add new item");
            await _dataService.AddToDoAsync(ToDo);
        }
        else
        {
            Debug.WriteLine("Update existing item");
            await _dataService.UpdateToDoAsync(ToDo.Id, ToDo);
        }

        await Shell.Current.GoToAsync("..");
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await _dataService.DeleteToDoAsync(ToDo.Id);
        await Shell.Current.GoToAsync("..");
    }
    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}