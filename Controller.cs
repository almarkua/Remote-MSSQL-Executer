using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace lab4_1_PRBD
{
    class CustomSqlParameter
    {
        public string Value { get; set; }
    }

    class Controller:INotifyPropertyChanged
    {
        private ISqlCommand SqlCommand;
        private string _connectionString;
        private string _query;
        private DataView _resultTable;
        private ObservableCollection<CustomSqlParameter> _parameters;
        public ICommand ExecuteButtonClickCommand { get; set; }
        public DataView ResultTable {
            get { return _resultTable; }
            set
            {
                _resultTable = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CustomSqlParameter> Parameters
        {
            get { return _parameters; }
            set
            {
                _parameters = value;
                OnPropertyChanged();
            }
        }
        private OleDbConnection _connection;
        public string Query {
            get { return _query; }
            set
            {
                _query = value;
                OnPropertyChanged();
            }
        }

        public Controller()
        {
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            _connectionString = settings[2].ConnectionString;
            ExecuteButtonClickCommand = new Command(ExecuteButtonClick);
            Parameters = new ObservableCollection<CustomSqlParameter>() {new CustomSqlParameter() {Value = "Markov"}};
            if (ConfigurationManager.AppSettings["ConnectionType"] == "ODBC")
            {
                SqlCommand = new OdbcSqlCommand();
            }
            else if (ConfigurationManager.AppSettings["ConnectionType"] == "OLEDB")
            {
                SqlCommand = new OleDbSqlCommand();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ExecuteButtonClick(object window)
        {
                try
                {
                    if (Query.Trim().ToLower().StartsWith("select"))
                    {
                        var table = SqlCommand.ExecuteReader(Query, Parameters.ToList());
                        ResultTable = table.DefaultView;
                    }
                    else
                    {
                        SqlCommand.ExecuteNonQuery(Query, Parameters.ToList());
                        ResultTable = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
    }
}
