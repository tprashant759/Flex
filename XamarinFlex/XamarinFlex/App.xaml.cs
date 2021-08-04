using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFlex.Database;
using XamarinFlex.Views;

namespace XamarinFlex
{
    public partial class App : Application
    {
        public static TodoDatabase Database { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.HomePage());
            GetDBInstance();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


        async void GetDBInstance()
        {
            Database = await TodoDatabase.Instance;
        }
    }
}
