﻿using ClinicAppointment.Appointments.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Appointments.service.interfaces
{
    public interface IAppointmentQueryService
    {
        Appointment GetById(int id);
        int GetLastId();
        List<Appointment> GetAllAppointments();
    }
}
