using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ECommerce.Services.System
{
    public class UrlService : IUrlService
    {
        public string GenerateSlug(string name)
        {
            string slug = Regex.Replace(name,@"[â-z0-9\s-]","");
            slug = Regex.Replace(slug, @"\s+", "-");
            slug = Regex.Replace(slug, @"\s", "-");
            return slug;
        }
    }
}
