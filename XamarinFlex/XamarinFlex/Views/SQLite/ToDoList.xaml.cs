using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinFlex.Views
{
    public partial class SQLiteFlex : ContentPage
    {
        public SQLiteFlex()
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.SQLiteFlexViewModel(this);
        }
    }
}
