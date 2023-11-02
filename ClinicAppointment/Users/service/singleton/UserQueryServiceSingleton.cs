using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Users.service.singleton
{
    public class UserQueryServiceSingleton
    {
        private static readonly Lazy<UserQueryService> _instance = new Lazy<UserQueryService>(() => new UserQueryService());

        public static UserQueryService Instance => _instance.Value;

        private UserQueryServiceSingleton() { }
    }
}
