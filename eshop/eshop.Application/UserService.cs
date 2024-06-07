using eshop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application
{
    public class UserService : IUserService
    {
        private List<User> users = new List<User>()
        {
            new User{ Id=1, FullName="Türkay Ürkmez", UserName="turkay", Password="123456", Email="a@b.com", Role="Admin"},
            new User{ Id=2, FullName="Furkan Başkan", UserName="furkan", Password="123456", Email="a@b.com", Role="Editor"},
            new User{ Id=3, FullName="Emre Kalyon", UserName="emre", Password="123456", Email="a@b.com", Role="Customer"},

        };

        public User ValidateUser(string userName, string password)
        {
            //ister db, LDAP (Active Directory) kullanın; kullanıcıyı doğrulayın.
            return users.SingleOrDefault(u => u.UserName == userName && u.Password == password);
        }
    }
}
