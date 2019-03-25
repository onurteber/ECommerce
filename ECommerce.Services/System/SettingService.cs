using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.System
{
    public class SettingService : ISettingService
    {
        private AppDbContext appDbContext = new AppDbContext();

        public T GetSetting<T>(string key) where T: IConvertible
        {
            var value = appDbContext.Settings.SingleOrDefault(x => x.Key == key).Value;
            return (T)Convert.ChangeType(value, typeof(T));
        }
        
    }
}
