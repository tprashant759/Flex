﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFlex.Views;

namespace XamarinFlex
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.HomePage());
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
    }
}
