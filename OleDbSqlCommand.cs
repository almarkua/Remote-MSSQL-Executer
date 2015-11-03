using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab4_1_PRBD
{
    class OleDbSqlCommand:ISqlCommand
    {
        public void ExecuteNonQuery(string query, List<CustomSqlParameter> parameters)
        {
            var _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OleDbConnection"].ConnectionString;
            using (OleDbConnection _connection = new OleDbConnection(_connectionString))
            {
                try
                {
                    _connection.Open();
                    OleDbCommand command = new OleDbCommand(query, _connection);
                    foreach (var customSqlParameter in parameters)
                    {
                        command.Parameters.Add(new OleDbParameter() { Value = customSqlParameter.Value });
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
            var _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OleDbConnection"].ConnectionString;
            using (OleDbConnection _connection = new OleDbConnection(_connectionString))
            {
                try
                {
                    _connection.Open();
                    OleDbCommand command = new OleDbCommand(query, _connection);
                    foreach (var customSqlParameter in parameters)
                    {
                        command.Parameters.Add(new OleDbParameter() { Value = customSqlParameter.Value });
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
