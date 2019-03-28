using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.User
{
    public interface IUserService
    {
        bool EmailControl(string Email);
        bool UserNameControl(string UserName);
        RegisterResult Register(ECommerce.Data.User User);
        void ActivateUserByGuid(string customerGuid);
        Data.User GetUserByUserNameCredantial(string UserName, string Password);
        Data.User GetUserByEmailCredantial(string Email, string Password);
        Data.User GetUserByUserName(string UserName);
        Data.User GetUserByEmail(string Email);
        bool ResetPassword(string Email);
        Data.User CreateGuestMember(string ipAddress);
        List<Data.User> GetUsers();
    }
}
