﻿using QuickCart.Views.LandingViews;

namespace QuickCart
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LandingPage();
        }
    }
}
