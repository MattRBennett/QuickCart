using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickCart.Services.Classes;

namespace QuickCart.Services.Interfaces
{
    public interface ICategoryServices
    {
        Task<List<MenuItems>> GetMenuItemsByCategoryID(int CategoryID);
    }
}
