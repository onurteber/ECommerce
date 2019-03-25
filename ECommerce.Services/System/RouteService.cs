using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.System
{
    public class RouteService : IRouteService
    {
        AppDbContext appDbContext = new AppDbContext();
        public string CheckUrl(string id)
        {
            if (appDbContext.Products.Any(f=>f.Slug ==id))
            {
                return "Products";
            }
            else if(appDbContext.Categories.Any(f => f.Slug == id))
            {
                return "Categories";
            }
            else
            {
                return "Error";
            }
        }
        
    }
}
