using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.utils
{
    public class Constants
    {
        public static readonly string ITEM_DEJA_EXISTENT_EXCEPTION = "Itemul exista deja in baza de date";

        public static readonly string ITEM_INEXISTENT_EXCEPTION = "Itemul nu exista in baza de date";

        public static readonly string CAMP_NECOMPLETAT_EXCEPTION = "Toate campurile sunt obligatorii";

        // DATE FORMATS
        public static readonly string STANDARD_DATE_FORMAT = "dd.MM.yyyy HH:mm";
        public static readonly string SQL_DATE_FORMAT = "yyyy-MM-dd HH:mm";
        public static readonly string STANDARD_DATE_DAYTIME_ONLY = "HH:mm";
        public static readonly string STANDARD_DATE_CALENDAR_DATE_ONLY = "dd.MM.yyyy";


    }
}
