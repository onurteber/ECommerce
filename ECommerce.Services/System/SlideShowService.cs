using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.System
{
    public class SlideShowService : ISlideShowService
    {
        AppDbContext appDbContext = new AppDbContext();
        public IQueryable<SlideShow> GetHomePageSlides()
        {
            return appDbContext.SlideShow;
        }
    }
}
