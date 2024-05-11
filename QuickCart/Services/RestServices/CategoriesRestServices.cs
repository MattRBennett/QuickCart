using QuickCart.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using QuickCart.Services;
using QuickCart.Services.Classes;

using JsonSerializer = System.Text.Json.JsonSerializer;


namespace QuickCart.Services.RestServices
{
    public class CategoriesRestServices : ICategoryServices
    {
        private readonly HttpClient client;
        readonly System.Text.Json.JsonSerializerOptions serializerOptions;


        public CategoriesRestServices() 
        { 
            client = new HttpClient();

        }

        public List<MenuItems> menuItems { get; private set; }
        public async Task<List<MenuItems>> GetMenuItemsByCategoryID(int cateogryID)
        {
            menuItems = new List<MenuItems>();
            Uri uri = new(string.Format(Constants.restURLIOS + $"Categories/GetMenuItemsByCategoryID?CategoryID={cateogryID}", string.Empty));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var Formatted = content.Remove(0, 9);
                    var FormatedFinal = Formatted.Split(",\"formatters\":[],\"contentTypes\":[],\"declaredType\":null,\"statusCode\":200}");
                    menuItems = JsonConvert.DeserializeObject<List<MenuItems>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return menuItems;
        }
    }
}
