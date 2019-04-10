using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
        public Photo UploadPicture(HttpPostedFileBase photo, string path)
        {
            if (photo != null && photo.ContentLength > 0)
            {
                var fileName = Path.GetFileName(photo.FileName);
                var filePath = Path.Combine(path, fileName);
                photo.SaveAs(filePath);
                Photo resim = new Photo();
                resim.FileUrl = "/uploads/" + fileName;
                resim.UserId = 4;
                resim.CreateDate = DateTime.Now;
                appDbContext.Photos.Add(resim);
                appDbContext.SaveChanges();
                return resim;
            }
            else
            {
                throw new Exception("Resim Bos!");
            }
        }


    }
}
