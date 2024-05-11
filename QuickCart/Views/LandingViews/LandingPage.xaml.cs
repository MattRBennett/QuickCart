using System.Drawing;
using System.Resources;
using System.Collections.Generic;
using QuickCart.Services;
using QuickCart.Services.RestServices;

namespace QuickCart.Views.LandingViews;

public partial class LandingPage : ContentPage
{
	public LandingPage()
	{
		InitializeComponent();

	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        CategoriesRestServices restServices = new CategoriesRestServices();

        var menuitems = await restServices.GetMenuItemsByCategoryID(2);

    }
}