using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DB
{
    public class Database
    {
        private SqlConnection conn;
        private SqlDataAdapter adapter;

        public Database(string server, string database)
        {
            string connStr = $"Data Source={server};Initial Catalog={database};Integrated Security=true";
            conn = new SqlConnection(connStr);
            adapter = new SqlDataAdapter();
        }

        public void Open()
        {
            if (conn == null)
            {
                throw new Exception("connection not created");
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void Close()
        {
            if (conn == null)
            {
                throw new Exception("connection not created");
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }  

        public SqlConnection GetConn()
        {
            return conn;
        }

        public bool Query(string row, out DataTable data)
        {
            try
            {
                row = SanitizeQueryRow(row);
                var cmd = new SqlCommand(row, conn);
                bool found = false;
                adapter.SelectCommand = cmd;
                data = new DataTable();
                if (adapter.Fill(data) != 0)
                {
                    var pk = GetPrimaryKey(data);
                    data.PrimaryKey = new DataColumn[] { pk };
                    found = true;
                }
                return found;
            }
            catch
            {
                data = null;
                return false;
            }
        }

        private DataColumn GetPrimaryKey(DataTable data)
        {
            DataColumn pk = null;
            for (int idx = 0; idx < data.Columns.Count;)
            {
                pk = data.Columns[idx];
                break;
            }
            return pk;
        }

        private string SanitizeQueryRow(string row)
        {
            return row.Trim()
                .Replace("\n", "")
                .Replace("\r", "")
                .Replace("\t", "");
        }

        public bool NonQuery(string row)
        {
            try
            {
                row = SanitizeQueryRow(row);
                var cmd = new SqlCommand(row, conn);
                var changed = cmd.ExecuteNonQuery();
                return Convert.ToBoolean(changed);
            }
            catch
            {
                return false;   
                throw;
            }
        }

        public bool Query(string row, out SqlDataReader data)
        {
            try
            {
                row = SanitizeQueryRow(row);
                var cmd = new SqlCommand(row, conn);
                bool found = false;
                data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    found = true;
                }
                return found;
            }
            catch
            {
                data = null;
                return false;
            }
        }

        public bool CallStorageProcedure(string procedure, Dictionary<string, object> parameters, Dictionary<string, SqlDbType> schema)
        {
            try
            {
                bool success = false;
                if (parameters.Count != schema.Count)
                {
                    return success;
                }
                var cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(parameter.Key, schema[parameter.Key]).Value = parameter.Value;
                }
                if (cmd.ExecuteNonQuery() != 0)
                {
                    success = true;
                }
                return success;
            }
            catch
            {
                return false;
            }
        }


        public bool CallStorageProcedure(string procedure, Dictionary<string, object> parameters, Dictionary<string, SqlDbType> schema,  out DataTable data)
        {
            try
            {
                bool success = false;
                data = new DataTable();
                if (parameters.Count != schema.Count)
                {
                    return success;
                }
                var cmd = new SqlCommand(procedure, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(parameter.Key, schema[parameter.Key]).Value = parameter.Value;
                }
                adapter.SelectCommand = cmd;
                data = new DataTable();
                if (adapter.Fill(data) != 0)
                {
                    success = true;
                }
                return success;
            }
            catch
            {
                data = null;
                return false;
            }
        }
    }
}
