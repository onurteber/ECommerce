using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECommerce.Services.System
{
    public interface IPhotoService
    {
        IQueryable<Photo> GetPhotosByIds(int[] ids);
        Photo GetPhotoById(int id);
        Photo UploadPicture(HttpPostedFileBase picture, string path);
    }
}
