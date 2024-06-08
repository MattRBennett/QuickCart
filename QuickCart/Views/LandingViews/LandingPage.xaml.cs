using System.Drawing;
using System.Resources;
using System.Collections.Generic;
using QuickCart.Services;
using QuickCart.Services.RestServices;
using System.Collections.ObjectModel;
using QuickCart.Services.Classes;

namespace QuickCart.Views.LandingViews;

public partial class LandingPage : ContentPage
{

    #region Lists

    ObservableCollection<Categories> CategoriesList = new();

    ObservableCollection<MenuItems> MenuItemList = new();

    #endregion
    public LandingPage()
	{
		InitializeComponent();

	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        CategoriesRestServices restServices = new CategoriesRestServices();

        //var menuitems = await restServices.GetMenuItemsByCategoryID(2);

        CategoriesList.Clear();

        var MenuCategories = await restServices.GetMenuCategories();

        foreach (var category in MenuCategories)
        {
            CategoriesList.Add(category);
        }

        CategoryCollectionView.ItemsSource = CategoriesList;
    }

    private async void CategoryItem_Clicked(object sender, EventArgs e)
    {
        CategoriesRestServices restServices = new CategoriesRestServices();

        if (sender is Button button && button.BindingContext is Categories categories)
        {
            if (categories != null)
            {
                MenuItemList.Clear();

                var menuitems = await restServices.GetMenuItemsByCategoryID(categories.CategoryID);

                foreach (var menuItem in menuitems)
                {
                    if (menuItem.CategoryID == categories.CategoryID) 
                    {
                        MenuItemList.Add(menuItem);
                    }
                    
                }

                MenuItemsCollectionView.ItemsSource = MenuItemList;
            }
        }
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
}