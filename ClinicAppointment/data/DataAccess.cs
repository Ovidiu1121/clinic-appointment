using ClinicAppointment.FreeSlots.model;
using ClinicScheduler.data;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicScheduler.data
{
    public class DataAccess : IDataAccess
    {
        public List<T> LoadData<T, U>(string sqlStatement, U parameters, String connectionString)
        {

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sqlStatement, parameters).ToList();

                return rows;

            }
        }

        public void SaveData<T>(string sqlstatement, T parameters, string connectionString)
        {

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {

                connection.Execute(sqlstatement, parameters);

            }
        }

        public async Task<IEnumerable<FreeSlot>>loadDataProcedure<FreeSlot, U>(string numeleProcedurii, U parameters, String connectionString)
        {

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<FreeSlot>(numeleProcedurii, parameters, commandType: CommandType.StoredProcedure);

                return rows;

            }
        }

    }
}
