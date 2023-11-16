using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.FreeSlots.model
{
    public interface IFreeSlot
    {
        AvailableSlots setStartDate(DateTime startDate);  
        AvailableSlots setEndDate(DateTime endDate);
    }
}
