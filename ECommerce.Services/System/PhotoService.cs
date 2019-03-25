using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Data;

namespace ECommerce.Services.System
{
    public class PhotoService : IPhotoService
    {
        AppDbContext appDbContext = new AppDbContext();
        
        
        
        public Photo GetPhotoById(int id)
        {
            return appDbContext.Photos.FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<Photo> GetPhotosByIds(int[] ids)
        {
            return appDbContext.Photos.Where(p => ids.Contains(p.Id));
        }
    }
}
