using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Data;
using ECommerce.Services.Communication;

namespace ECommerce.Services.User
{
    public class UserService : IUserService
    {
        private AppDbContext appDbContext = new AppDbContext();
        private IEmailSenderService _emailSenderService;
        public UserService(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }

        public Data.User CreateGuestMember(string ipAddress)
        {
            var user = new Data.User();
            user.Active = true;
            user.LastLoginDate = DateTime.Now;
            user.ApprovedEmail = true;
            user.RegisterDate = DateTime.Now;
            user.Guid = Guid.NewGuid();
            user.Email = ipAddress;
            user.LastLoginIp = ipAddress;
            user.Name = "Guest";
            user.LastName = "Guest";
            user.Password = Guid.NewGuid().ToString();
            user.Role = "Guest";
            appDbContext.Users.Add(user);
            appDbContext.SaveChanges();
            return user;
        }

        public void ActivateUserByGuid(string customerGuid)
        {
            var customer = appDbContext.Users.FirstOrDefault(m => m.Guid.ToString() == customerGuid);
            customer.ApprovedEmail = true;
            //appDbContext.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            appDbContext.SaveChanges();
        }

        public bool EmailControl(string email)
        {
            return appDbContext.Users.Any(u => u.Email == email);
        }

        public List<Data.User> GetUsers()
        {
            return appDbContext.Users.ToList();
        }

        public Data.User GetUserByEmail(string Email)
        {
            return appDbContext.Users.SingleOrDefault(u => u.Email == Email);
        }

        public Data.User GetUserByEmailCredantial(string Email, string Password)
        {
            return appDbContext.Users.SingleOrDefault(u => u.Email == Email && u.Password == Password);
        }

        public Data.User GetUserByUserName(string UserName)
        {
            return appDbContext.Users.SingleOrDefault(u => u.UserName == UserName);
        }

        public Data.User GetUserByUserNameCredantial(string UserName, string Password)
        {
            return appDbContext.Users.SingleOrDefault(u => u.UserName == UserName && u.Password == Password);
        }

        public RegisterResult Register(Data.User user)
        {
                user.RegisterDate = DateTime.Now;
                user.Active = true;
                user.ApprovedEmail = false;
                user.Guid = Guid.NewGuid();

            _emailSenderService.Send(new EmailMessageModel
            {
                Receiver = new List<string> { user.Email },
                Subject = "Üyeliği Aktifleştir",
                MessageBody = "Üyeliğiniz Oluşturuldu. <a href=\"http://localhost:54244/User/ConfirmEmail?CustomerGuid=" + user.Guid.ToString() + " \"> Aktifleştirin</a> "
            });
            appDbContext.Users.Add(user);
            appDbContext.SaveChanges();
            return RegisterResult.Successful;
            
        }

        public bool ResetPassword(string Email)
        {
            var user = appDbContext.Users.SingleOrDefault(u => u.Email == Email);
            if(user != null)
            {
                Random rastgele = new Random();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 10; i++)
                {
                    int ascii = rastgele.Next(97, 122);
                    char karakter = Convert.ToChar(ascii);
                    sb.Append(karakter);

                }
                string a = "";
                user.Password = sb.ToString();
                _emailSenderService.Send(new EmailMessageModel
                {
                    Receiver = new List<string> { user.Email },
                    Subject = "Şifreniz Güncellendi",
                    MessageBody = "Yeni Şifreniz : " + sb + " <a href=\"http://localhost:54244/Home/Index" + a + " \"> Hemen Giriş Yapmak İçin Tıkla</a> "
                });
                appDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UserNameControl(string UserName)
        {
            return appDbContext.Users.Any(u => u.UserName == UserName);
        }
    }
}
