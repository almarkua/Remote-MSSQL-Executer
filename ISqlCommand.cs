using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_1_PRBD
{
    interface ISqlCommand
    {
        DataTable ExecuteReader(string query, List<CustomSqlParameter> parameters);
        void ExecuteNonQuery(string query, List<CustomSqlParameter> parameters);
    }
}
