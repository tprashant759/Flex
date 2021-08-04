using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinFlex.Views.SQLite
{
    public partial class AddToDoItem : ContentPage
    {
        public AddToDoItem(ViewModels.SQLiteFlexViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}
