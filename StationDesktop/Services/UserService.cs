using StationDesktop.Models;
using System.Linq;

namespace StationDesktop.Services
{
    public static class UserService
    {
        public static User User { get; set; }

        public static string Position
        {
            get
            {
                switch(User.PositionCode)
                {
                    case 1: return "Дежурный";
                        break;
                    case 2: return "Приемосдатчик";
                            break;
                    default: return "Сотрудник";
                            break; ;
                }
            }
        }

        public static bool CheckUser(string login, string password, StationContext context)
        {
            var user = context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            if (user != null)
                return true;
            else return false;
        }
    }
}
