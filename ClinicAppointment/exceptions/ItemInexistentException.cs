using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicScheduler.exceptii
{
    public class ItemInexistentException : Exception
    {
        public ItemInexistentException() { }

        public ItemInexistentException(string message) : base(message) { }

        public ItemInexistentException(string message, Exception innerException) : base(message, innerException) { }
    }
}
