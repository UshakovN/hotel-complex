using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Types;
using DB;

namespace HotelComplex
{
    public class Handler
    {
        private readonly string valueNULL = "NULL";
        private readonly string serverName = "USHAKOV-PC";
        private readonly string databaseName = "hotel_complex";

        private Database db;

        public Handler()
        {
            db = new Database(serverName, databaseName);
        }

        public bool Search(string table, string filter, Dictionary<string, Type> schema, out DataTable items)
        {
            db.Open();
            filter = filter.Trim().ToLower();
            string query = $"SELECT * FROM {table} WHERE ";
            string queryKeys = "";
            foreach (var value in schema)
            {
                queryKeys += $"{value.Key}, ";
            }
            queryKeys = queryKeys.TrimEnd(',', ' ');
            query += $"CONCAT({queryKeys}) LIKE \'%{filter}%\'";
            var found = db.Query(query, out items);
            db.Close();
            return found;
        }

        public bool Put(string table, Dictionary<string, object> data, Dictionary<string, Type> schema = null)
        {
            db.Open();
            string query = $"INSERT INTO {table} ";
            string queryKeys = "";
            string queryValues = "";
            foreach (var value in data)
            {
                queryKeys += $"{value.Key}, ";
                queryValues += $"{EscapeValue(value.Value, schema[value.Key])}, ";
            }
            queryKeys = queryKeys.TrimEnd(',', ' ');
            queryValues = queryValues.TrimEnd(',', ' ');
            query += $"({queryKeys}) VALUES ({queryValues})";
            var success = db.NonQuery(query);
            db.Close();
            return success;
        }

        public bool Delete(string table, Dictionary<DataColumn, object> keys)
        {
            db.Open();
            string query = $"DELETE FROM {table} WHERE ";
            string queryFilters = "";
            foreach (var k in keys)
            {
                queryFilters += $"{k.Key.ColumnName}={EscapeValue(k.Value, k.Key.DataType)}, ";
            }
            queryFilters = queryFilters.TrimEnd(',', ' ');
            query += queryFilters;
            var success = db.NonQuery(query);
            db.Close();
            return success;
        }

        public bool Update(string table, Dictionary<DataColumn, object> keys, Dictionary<string, object> values, Dictionary<string, Type> schema = null)
        {
            db.Open();
            string query = $"UPDATE {table} ";
            string querySet = "";
            foreach (var value in values)
            {
                querySet += $"{value.Key}={EscapeValue(value.Value, schema[value.Key])}, ";
            }
            querySet = querySet.TrimEnd(',', ' ');
            string queryFilters = "";
            foreach (var k in keys)
            {
                queryFilters += $"{k.Key.ColumnName}={EscapeValue(k.Value, k.Key.DataType)}, ";
            }
            queryFilters = queryFilters.TrimEnd(',', ' ');
            query += $"SET {querySet} WHERE {queryFilters}";
            var success = db.NonQuery(query);
            db.Close();
            return success;
        }

        public bool GetTableNames(out string[] tables)
        {
            db.Open();
            tables = null;
            var tableName = "TABLE_NAME";
            var found = db.Query($"SELECT {tableName} FROM {databaseName}.INFORMATION_SCHEMA.TABLES", out SqlDataReader data);
            if (!found)
            {
                return false;
            }
            var tablesList = new List<string>();
            for (int idx = 0; data.Read(); idx++)
            {
                tablesList.Add(data[tableName].ToString());
            }
            tables = tablesList.ToArray();
            Array.Sort(tables);
            db.Close();
            return true;
        }

        public bool GetStoredProcedureNames(out string[] procedures)
        {
            db.Open();
            procedures = null;
            var procName = "ROUTINE_NAME";
            var query = $"SELECT {procName} FROM {databaseName}.INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = \'PROCEDURE\'";
            var found = db.Query(query, out SqlDataReader data);
            if (!found)
            {
                return false;
            }
            var tablesList = new List<string>();
            for (int idx = 0; data.Read(); idx++)
            {
                tablesList.Add(data[procName].ToString());
            }
            procedures = tablesList.ToArray();
            Array.Sort(procedures);
            db.Close();
            return true;
        }

        public bool Scan(string table, out DataTable items)
        {
            db.Open();
            var found = db.Query($"SELECT * FROM {table}", out DataTable data);
            items = data;
            items.TableName = table;
            db.Close();
            return found;
        }

        private object EscapeValue(object value, Type type = null)
        {
            if (value.GetType() == typeof(DBNull))
            {
                return valueNULL;
            }
            if (type != null)
            {
                if (type == typeof(string) || type == typeof(DateTime))
                {
                    value = $"\'{value.ToString().Trim(' ', '\n', '\r', '\t')}\'";
                }
                else if (type == typeof(int))
                {
                    if (Cast.TryConvertObject(value, out int output))
                    {
                        value = output;
                    }
                }
                return value;
            }
            if (!Cast.TryConvertObject(value, out int _))
            {
                value = $"\'{value}\'";
            }
            return value;
        }

        public bool OrderHistoryByClient(string report, object client, out DataTable data)
        {
            db.Open();
            var clientKey = "@client";
            var parameters = new Dictionary<string, object>()
            {
                { clientKey, client },
            };
            var schema = new Dictionary<string, SqlDbType>()
            {
                { clientKey,  SqlDbType.VarChar },
            };
            var success = db.CallStorageProcedure(report, parameters, schema, out DataTable items);
            data = items;
            db.Close();
            return success;
        }

        public bool ClientInformationByRoom(string report, object room, out DataTable data)
        {
            db.Open();
            var roomKey = "@room";
            var parameters = new Dictionary<string, object>()
            {
                { roomKey,  room },
            };
            var schema = new Dictionary<string, SqlDbType>()
            {
                { roomKey,  SqlDbType.Int },
            };
            var success = db.CallStorageProcedure(report, parameters, schema, out DataTable items);
            data = items;
            db.Close();
            return success;
        }

        public bool ChangeBookingOrderCost(string report, object category, object cost)
        {
            db.Open();
            var categoryKey = "@category";
            var costKey = "@cost";
            var parameters = new Dictionary<string, object>()
            {
                { categoryKey, category },
                { costKey, cost },
            };
            var schema = new Dictionary<string, SqlDbType>()
            {
                { categoryKey,  SqlDbType.VarChar },
                { costKey, SqlDbType.Real },
            };
            var success = db.CallStorageProcedure(report, parameters, schema);
            db.Close();
            return success;
        }

        public bool BookingByOrganization(string report, out DataTable data)
        {
            db.Open();
            var parameters = new Dictionary<string, object>();
            var schema = new Dictionary<string, SqlDbType>();
            var success = db.CallStorageProcedure(report, parameters, schema, out DataTable items);
            data = items;
            db.Close();
            return success;
        }

        public bool ClientsOrOrganizationInfoOrBooking(string report, object stayDate, object outDate, out DataTable data)
        {
            db.Open();
            var stayDateKey = "@stay_date";
            var outDateKey = "@out_date";
            var parameters = new Dictionary<string, object>()
            {
                { stayDateKey, stayDate },
                { outDateKey, outDate },
            };
            var schema = new Dictionary<string, SqlDbType>()
            {
                { stayDateKey,  SqlDbType.DateTime },
                { outDateKey, SqlDbType.DateTime },
            };
            var success = db.CallStorageProcedure(report, parameters, schema, out DataTable items);
            data = items;
            db.Close();
            return success;
        }

        public bool EmptyOrBookedRoomReport(string report, object date, out DataTable data)
        {
            db.Open();
            var dateKey = "@date";
            var parameters = new Dictionary<string, object>()
            {
                { dateKey, date },
            };
            var schema = new Dictionary<string, SqlDbType>()
            {
                { dateKey, SqlDbType.DateTime },
            };
            var success = db.CallStorageProcedure(report, parameters, schema, out DataTable items);
            data = items;
            db.Close();
            return success;
        }

        public bool GetRoomLocationsNames(out object[] locations)
        {
            db.Open();
            locations = null;
            var locationName = "location_name";
            var found = db.Query($"SELECT {locationName} FROM room_location", out SqlDataReader data);
            if (!found)
            {
                return false;
            }
            var locationsList = new List<string>();
            for (int idx = 0; data.Read(); idx++)
            {
                locationsList.Add(data[locationName].ToString());
            }
            locations = locationsList.ToArray();
            Array.Sort(locations);
            db.Close();
            return found;
        }

        public bool GetRoomLocations(out DataTable data)
        {
            db.Open();
            var found = db.Query($"SELECT * FROM room_location", out DataTable items);
            data = items;
            db.Close();
            return found;
        }
    }
}
