using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveGood.Classes
{
    static class User
    {
        public static int roleID;
        public static int userID;
        public static string roleName;
        public static string userName;
        public static string userSurname;
        public static string userPatronymic;
        public static string userDisrict;
        public static string userPhoto;
        public static bool show = false;
        public static Model.District district;
        public enum Role
        {
            Организатор,
            Менеджер,
            Волонтер
        }
    }
}
