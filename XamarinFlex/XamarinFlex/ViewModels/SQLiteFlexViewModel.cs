using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Acr.UserDialogs;
using Shared;
using Xamarin.Forms;

namespace XamarinFlex.ViewModels
{
    public class SQLiteFlexViewModel : BaseViewModel
    {

        #region Properties

        private ObservableCollection<ToDoItem> toDoList;

        public ObservableCollection<ToDoItem> ToDoList
        {
            get { return toDoList; }
            set { toDoList = value; OnPropertyChanged(); }
        }

        private ToDoItem selectedToDoItem;

        public ToDoItem SelectedToDoItem
        {
            get { return selectedToDoItem; }
            set { selectedToDoItem = value; OnPropertyChanged(); }
        }


        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(); }
        }



        #endregion

        #region Constructors

        public SQLiteFlexViewModel(ContentPage page)
        {
            m_view = page;
            InitializePage();
            m_view.Appearing += M_view_Appearing;
        }


        void InitializePage()
        {
            try
            {
         

            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
        }

        private async void M_view_Appearing(object sender, EventArgs e)
        {
            try
            {
                UserDialogs.Instance.ShowLoading();

                ToDoList = new ObservableCollection<ToDoItem>();
                ToDoList.Add(new ToDoItem { id = Guid.NewGuid(), Title = "Go for a walk", Description = "6 am sharp , 5 km walk .", Done = 0 });
                ToDoList.Add(new ToDoItem { id = Guid.NewGuid(), Title = "Brakfast", Description = "8 am sharp , caloty deficit diet .", Done = 0 });
                ToDoList.Add(new ToDoItem { id = Guid.NewGuid(), Title = "Excercise", Description = "5 pm sharp , 15 mins HIIT .", Done = 0 });

                foreach (var item in ToDoList)
                    await App.Database.SaveOrUpdateItemAsync(item);

                ToDoList = new ObservableCollection<ToDoItem>(await App.Database.GetAllItemsAsync()); ;
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                HandleExceptions(ex);
            }
        }

        #endregion

        #region Commands

        public ICommand OpenAddToDoItemCommand { get { return new Command(OpenAddToDoItemAction); } }
        public ICommand AddToDoItemCommand { get { return new Command(AddToDoItemAction); } }
        public ICommand DeleteToDoItemCommand { get { return new Command(DeleteToDoItemAction); } }
        public ICommand MarkDoneToDoItemCommand { get { return new Command(MarkDoneToDoItemAction); } }

        #endregion

        #region Methods

        private async void OpenAddToDoItemAction(object obj)
        {
            try
            {
                await m_view.Navigation.PushAsync(new Views.SQLite.AddToDoItem(this));
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
        }

        private async void AddToDoItemAction(object obj)
        {
            try
            {
                ToDoItem item = new ToDoItem();
                item.Description = Description;
                item.Title = Title;

                await App.Database.SaveOrUpdateItemAsync(item);
                await m_view.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
        }

        private async void DeleteToDoItemAction(object obj)
        {
            try
            {
                var item = obj as ToDoItem;
                await App.Database.DeleteItemAsync(item);

                ToDoList = new ObservableCollection<ToDoItem>(await App.Database.GetAllItemsAsync());
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
        }

        private async void MarkDoneToDoItemAction(object obj)
        {
            try
            {
                SelectedToDoItem.Done = 1;
                await App.Database.SaveOrUpdateItemAsync(SelectedToDoItem);
                await m_view.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
        }

        #endregion
    }
}
