using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendisReservationAutomatically.Constants
{
    public class Constant
    {
        public static string CalendisUrl = ConfigurationManager.AppSettings["CalendisUrl"];
        public static string Email = ConfigurationManager.AppSettings["Email"];
        public static string Password = ConfigurationManager.AppSettings["Password"];
        public static string SportLink = ConfigurationManager.AppSettings["MagicLink"];
        public static string GoodHours = ConfigurationManager.AppSettings["GoodHours"];
        public static string GoodDays = ConfigurationManager.AppSettings["GoodDays"];
    }
}
