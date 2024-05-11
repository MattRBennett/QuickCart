using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickCart.Services.Classes;
using QuickCart.Services.Interfaces;

namespace QuickCart.Services
{
    public class ServiceManager
    {
        private readonly ICategoryServices _categoryServices;

        public ServiceManager(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public Task<List<MenuItems>> GetMenuItemsByCateogryID(int cateogryID)
        {
            return _categoryServices.GetMenuItemsByCategoryID(cateogryID);
        }

    }
}
