using System.Diagnostics;
using ToDo.MauiClient.DataServices;
using ToDo.MauiClient.Pages;
using ToDo.MauiClient.Models;

namespace ToDo.MauiClient
{
    public partial class MainPage : ContentPage
    {
        private readonly IRestDataService _dataService;

        public MainPage(IRestDataService dataService)
        {
            InitializeComponent();

            _dataService = dataService;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await _dataService.GetAllToDosAsync();
        }

        async void OnAddTodoClicked(object sender, EventArgs e)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                {nameof(ToDo), new ToDoItem() }
            };
            await Shell.Current.GoToAsync(nameof(ManageToDoPage), navigationParameter);
            Debug.WriteLine("Add to do clicked");
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("To Do Selected changed");
            var navigationParameter = new Dictionary<string, object>
            {
                {nameof(ToDoItem), e.CurrentSelection.FirstOrDefault() as ToDoItem }
            };
            await Shell.Current.GoToAsync(nameof(ManageToDoPage), navigationParameter);
        }

    }
}
