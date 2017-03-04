

using System.Linq;
using System.Text.RegularExpressions;
using IssueTakerApp.BindingModels;
using IssueTakerApp.Models;
using IssueTakerApp.Models.Enums;
using SimpleHttpServer.Models;

namespace IssueTakerApp.Service
{
   public  class UserService : Services
    {
       public UserService() : base() { }

       public string ValidateUser(RegisterUserBM model)
       {

           var pattern = "((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*,.]).{6,})";
            var regPassword = Regex.Match(model.Password, pattern);
            if (Data.Data.Contex.Users.Any(x => x.Username == model.Username))
            {
                return "We have same user int hte base";
            }
            if (model.Username.Length < 5 || model.Username.Length > 30)
            {
                return "Username have to be between 5 and 30 symbols";
            }
            if (model.Fullname.Length < 5 )
            {
                return "Fullname have to be at least 5 symbols";
            }
            if (model.Password.Length < 8 || !regPassword.Success)
            {
                return "Password must be at least 8 symbols and contain a capital letter, a number and one of the following signs: [!@#$%^&*,.]";
            }
            if (!model.Password.Equals(model.PassCheck))
            {
                return "Both Passwords not match";
            }

            return "OK";
        }

        public void AddUser(RegisterUserBM model)
        {
            var user = new User();
            user.Username = model.Username;
            user.Fullname = model.Fullname;
            user.Password = model.Password;
            if (Data.Data.Contex.Users.Count() == 0)
            {
                user.Role = Role.Administrator;
            }
            else
            {
                user.Role = Role.Regular;
            }
            Data.Data.Contex.Users.Add(user);
            Data.Data.Contex.SaveChanges();
        }
        public bool LoginUser(LoginBM model, HttpSession session)
        {
            var user = Data.Data.Contex.Users.FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);
            if (user != null)
            {
                var sessio = new Sessions();
                sessio.SessionId = session.Id;
                sessio.IsActive = true;
                sessio.User = user;

                Data.Data.Contex.Sessions.Add(sessio);
                Data.Data.Contex.SaveChanges();
                return true;
            }

            return false;
        }
    }
    
}
