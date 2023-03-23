using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveGood.Classes
{
    static class DBHelper
    {
        public static Model.GiveGoodEntities DB { get; set; }
        public static int RoleID;
        public static int UserID;
        public static string UserNameFull;
    }
}
