using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinFlex.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.HomePageViewModel(this);
        }
    }
}
