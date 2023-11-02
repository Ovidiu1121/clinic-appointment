using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.exceptii
{
    public class ItemDejaExistentException : Exception
    {
        public ItemDejaExistentException() { }

        public ItemDejaExistentException(string message) : base(message) { }

        public ItemDejaExistentException(string message, Exception innerException) : base(message, innerException) { }

    }
}
