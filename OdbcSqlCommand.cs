using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_1_PRBD
{
    class OdbcSqlCommand:ISqlCommand
    {
        public void ExecuteNonQuery(string query, List<CustomSqlParameter> parameters)
        {
            var _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OdbcConnection"].ConnectionString;
            using (OdbcConnection _connection = new OdbcConnection(_connectionString))
            {
                try
                {
                    _connection.Open();
                    OdbcCommand command = new OdbcCommand(query, _connection);
                    foreach (var customSqlParameter in parameters)
                    {
                        command.Parameters.Add(new OdbcParameter() { Value = customSqlParameter.Value });
                    }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataTable ExecuteReader(string query, List<CustomSqlParameter> parameters)
        {
            var _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OdbcConnection"].ConnectionString;
            using (OdbcConnection _connection = new OdbcConnection(_connectionString))
            {
                try
                {
                    _connection.Open();
                    OdbcCommand command = new OdbcCommand(query, _connection);
                    foreach (var customSqlParameter in parameters)
                    {
                        command.Parameters.Add(new OdbcParameter() { Value = customSqlParameter.Value });
                    }
                    var table = new DataTable();
                    table.Load(command.ExecuteReader());
                    return table;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
