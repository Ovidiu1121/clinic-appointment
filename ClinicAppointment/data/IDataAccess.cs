using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicScheduler.data
{
    public interface IDataAccess
    {
        List<T> LoadData<T, U>(string sqlStatement, U parameters, String connectionString);

        void SaveData<T>(string sqlstatement, T parameters, string connectionString);

    }
}
