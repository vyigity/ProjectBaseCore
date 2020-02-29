using ProjectBaseCore.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;

namespace ProjectBaseCore.Database
{
    //vyigity
    public class SqlDatabase2 : DatabaseBase, IDisposable, IDatabase2, IDatabaseAsync2
    {
        /// <summary>
        /// Instantiates a new database interaction object.
        /// </summary>
        public SqlDatabase2() : base() { }
        /// <summary>
        /// Instantiates a new database interaction object.
        /// </summary>
        public SqlDatabase2(DbSettings setting) : base(setting) { }
        /// <summary>
        /// Instantiates a new database interaction object.
        /// </summary>
        public SqlDatabase2(DbSettings setting, IsolationLevel isolation) : base(setting, isolation) { }
        /// <summary>
        /// Executes a sql select query and returns results as a data table object.
        /// </summary>
        public override DataTable ExecuteQueryDataTable(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                GetConnection();
                SqlDataAdapter adap = new SqlDataAdapter(new SqlCommand(query, myCon as SqlConnection, tran as SqlTransaction));
                adap.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Executes a sql select Command and returns results as a data table object.
        /// </summary>
        public override DataTable ExecuteQueryDataTable(IDbCommand query)
        {
            DataTable dt = new DataTable();
            SqlCommand Command = query as SqlCommand;

            try
            {
                GetConnection();
                query.Transaction = tran;
                query.Connection = myCon;
                SqlDataAdapter adap = new SqlDataAdapter(Command);
                adap.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Executes a sql select query and fills a dataset object.
        /// </summary>
        public override void FillObject(DataSet set, string table, string query)
        {
            try
            {
                GetConnection();
                SqlDataAdapter adap = new SqlDataAdapter(new SqlCommand(query, myCon as SqlConnection, tran as SqlTransaction));
                adap.Fill(set, table);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Executes a sql select Command and fills a dataset object.
        /// </summary>
        public override void FillObject(DataSet set, string table, IDbCommand query)
        {
            query.Connection = myCon;
            SqlCommand Command = query as SqlCommand;

            try
            {
                GetConnection();
                query.Transaction = tran;
                SqlDataAdapter adap = new SqlDataAdapter(Command);
                adap.Fill(set, table);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Executes a sql select query and fills a data table object.
        /// </summary>
        public override void FillObject(DataTable table, string query)
        {
            try
            {
                GetConnection();
                SqlDataAdapter adap = new SqlDataAdapter(new SqlCommand(query, myCon as SqlConnection, tran as SqlTransaction));
                adap.Fill(table);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Executes a sql select Command and fills a data table object.
        /// </summary>
        public override void FillObject(DataTable table, IDbCommand query)
        {
            SqlCommand Command = query as SqlCommand;

            try
            {
                GetConnection();
                query.Transaction = tran;
                query.Connection = myCon;
                SqlDataAdapter adap = new SqlDataAdapter(Command);
                adap.Fill(table);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Executes a sql query and returns affected row count.
        /// </summary>
        public override int ExecuteQuery(string query)
        {
            SqlCommand Command = null;

            try
            {
                GetConnection();
                Command = new SqlCommand(query, myCon as SqlConnection, tran as SqlTransaction);
                return Command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Executes a sql Command and returns affected row count.
        /// </summary>
        public override int ExecuteQuery(IDbCommand query)
        {
            try
            {
                GetConnection();
                query.Transaction = tran;
                query.Connection = myCon;
                return query.ExecuteNonQuery(); ;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Executes a sql select query and returns results result as a single value.
        /// </summary>
        public override object GetSingleValue(string query)
        {
            SqlCommand Command = null;
            try
            {
                GetConnection();
                Command = new SqlCommand(query, myCon as SqlConnection, tran as SqlTransaction);
                return Command.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }

        }
        /// <summary>
        /// Executes a sql select Command and returns results result as a single value.
        /// </summary>
        public override object GetSingleValue(IDbCommand query)
        {
            try
            {
                GetConnection();
                query.Transaction = tran;
                query.Connection = myCon;
                return query.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }

        }
        /// <summary>
        /// Executes a sql select query and returns a data reader object.
        /// </summary>
        public override IDataReader GetDataReader(string query)
        {
            SqlCommand command = null;

            try
            {
                GetConnection();
                command = new SqlCommand(query, myCon as SqlConnection, tran as SqlTransaction);
                return command.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Executes a sql select Command and returns a data reader object.
        /// </summary>
        public override IDataReader GetDataReader(IDbCommand query)
        {
            try
            {
                GetConnection();
                query.Transaction = tran;
                query.Connection = myCon;
                return query.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Executes a sql select query and returns results as a desired type object.
        /// </summary>
        public override T GetObject<T>(string query)
        {
            SqlDataReader reader = GetDataReader(query) as SqlDataReader;

            try
            {
                T instance = (T)Activator.CreateInstance(typeof(T));

                reader.Read();

                var props = typeof(T).GetProperties();

                foreach (PropertyInfo inf in props)
                {
                    if (HasColumn(reader, inf.Name))
                    {
                        inf.SetValue(instance, Util.IsNull(reader[inf.Name]) ? null : Util.GetProperty(reader[inf.Name], inf.PropertyType));
                    }
                }

                return instance;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!reader.IsClosed)
                    reader.Close();

                Close();
            }
        }
        /// <summary>
        /// Executes a sql select Command and returns results as a desired type object.
        /// </summary>
        public override T GetObject<T>(IDbCommand query)
        {
            SqlDataReader reader = GetDataReader(query) as SqlDataReader;

            try
            {
                T instance = (T)Activator.CreateInstance(typeof(T));

                reader.Read();

                var props = typeof(T).GetProperties();

                foreach (PropertyInfo inf in props)
                {
                    if (HasColumn(reader, inf.Name))
                    {
                        inf.SetValue(instance, Util.IsNull(reader[inf.Name]) ? null : Util.GetProperty(reader[inf.Name], inf.PropertyType));
                    }
                }

                return instance;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!reader.IsClosed)
                    reader.Close();

                Close();
            }
        }
        /// <summary>
        /// Executes a sql select query and returns results as a list of desired type objects.
        /// </summary>
        public override List<T> GetObjectList<T>(string query)
        {
            SqlDataReader reader = GetDataReader(query) as SqlDataReader;
            List<T> entityList = new List<T>();

            try
            {
                var props = typeof(T).GetProperties();

                while (reader.Read())
                {
                    T instance = (T)Activator.CreateInstance(typeof(T));

                    foreach (PropertyInfo inf in props)
                    {
                        if (HasColumn(reader, inf.Name))
                        {
                            inf.SetValue(instance, Util.IsNull(reader[inf.Name]) ? null : Util.GetProperty(reader[inf.Name], inf.PropertyType));
                        }
                    }

                    entityList.Add(instance);
                }

                return entityList;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!reader.IsClosed)
                    reader.Close();

                Close();
            }
        }
        /// <summary>
        /// Executes a sql select Command and returns results as a list of desired type objects.
        /// </summary>
        public override List<T> GetObjectList<T>(IDbCommand query)
        {
            SqlDataReader reader = GetDataReader(query) as SqlDataReader;
            List<T> entityList = new List<T>();

            try
            {
                var props = typeof(T).GetProperties();

                while (reader.Read())
                {
                    T instance = (T)Activator.CreateInstance(typeof(T));

                    foreach (PropertyInfo inf in props)
                    {
                        if (HasColumn(reader, inf.Name))
                        {
                            inf.SetValue(instance, Util.IsNull(reader[inf.Name]) ? null : Util.GetProperty(reader[inf.Name], inf.PropertyType));
                        }
                    }

                    entityList.Add(instance);
                }

                return entityList;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!reader.IsClosed)
                    reader.Close();

                Close();
            }
        }
        /// <summary>
        /// Verifies if a data record has desired column using case insensitive compare methot.
        /// </summary>
        public override bool HasColumn(IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        protected override IDbConnection GetDbSpecificConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Asynchronously executes a sql query and returns affected row count.
        /// </summary>
        public Task<int> ExecuteQueryAsync(string query)
        {
            SqlCommand Command = null;

            try
            {
                GetConnection();
                Command = new SqlCommand(query, myCon as SqlConnection, tran as SqlTransaction);
                return Task.Run(() => { return Command.ExecuteNonQuery(); });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Asynchronously executes a sql Command and returns affected row count.
        /// </summary>
        public Task<int> ExecuteQueryAsync(IDbCommand query)
        {
            try
            {
                GetConnection();
                query.Transaction = tran;
                query.Connection = myCon;
                return Task.Run(() => { return query.ExecuteNonQuery(); });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Asynchronously executes a sql select query and returns results as a data table object.
        /// </summary>
        public Task<DataTable> ExecuteQueryDataTableAsync(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                GetConnection();
                SqlDataAdapter adap = new SqlDataAdapter(new SqlCommand(query, myCon as SqlConnection, tran as SqlTransaction));
                return Task.Run(() => { adap.Fill(dt); return dt; });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Asynchronously executes a sql select Command and returns results as a data table object.
        /// </summary>
        public Task<DataTable> ExecuteQueryDataTableAsync(IDbCommand query)
        {
            DataTable dt = new DataTable();
            SqlCommand Command = query as SqlCommand;

            try
            {
                GetConnection();
                query.Transaction = tran;
                query.Connection = myCon;
                SqlDataAdapter adap = new SqlDataAdapter(Command);
                return Task.Run(() => { adap.Fill(dt); return dt; });
            }
            catch (SqlException ex)
            {;
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Asynchronously executes a sql select query and fills a dataset object.
        /// </summary>
        public Task FillObjectAsync(DataTable table, string query)
        {
            try
            {
                GetConnection();
                SqlDataAdapter adap = new SqlDataAdapter(new SqlCommand(query, myCon as SqlConnection, tran as SqlTransaction));
                return Task.Run(() => { adap.Fill(table); return table; });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Asynchronously executes a sql select Command and fills a dataset object.
        /// </summary>
        public Task FillObjectAsync(DataTable table, IDbCommand query)
        {
            SqlCommand Command = query as SqlCommand;

            try
            {
                GetConnection();
                query.Transaction = tran;
                query.Connection = myCon;
                SqlDataAdapter adap = new SqlDataAdapter(Command);
                return Task.Run(() => { adap.Fill(table); return table; });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Asynchronously executes a sql select query and fills a data table object.
        /// </summary>
        public Task FillObjectAsync(DataSet set, string table, string query)
        {
            try
            {
                GetConnection();
                SqlDataAdapter adap = new SqlDataAdapter(new SqlCommand(query, myCon as SqlConnection, tran as SqlTransaction));
                return Task.Run(() => { adap.Fill(set, table); });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Asynchronously executes a sql select Command and fills a data table object.
        /// </summary>
        public Task FillObjectAsync(DataSet set, string table, IDbCommand query)
        {
            query.Connection = myCon;
            query.Transaction = tran;
            SqlCommand Command = query as SqlCommand;

            try
            {
                GetConnection();
                SqlDataAdapter adap = new SqlDataAdapter(Command);
                return Task.Run(() => { adap.Fill(set, table); });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Asynchronously executes a sql select query and returns a data reader object.
        /// </summary>
        public Task<IDataReader> GetDataReaderAsync(string query)
        {
            SqlCommand command = null;

            try
            {
                GetConnection();
                command = new SqlCommand(query, myCon as SqlConnection, tran as SqlTransaction);
                return Task.Run(() => { return (IDataReader)command.ExecuteReader(); });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Asynchronously executes a sql select Command and returns a data reader object.
        /// </summary>
        public Task<IDataReader> GetDataReaderAsync(IDbCommand query)
        {
            try
            {
                GetConnection();
                query.Transaction = tran;
                query.Connection = myCon;
                return Task.Run(() => { return (IDataReader)query.ExecuteReader(); });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Asynchronously executes a sql select query and returns results as a desired type object.
        /// </summary>
        public Task<T> GetObjectAsync<T>(string query)
        {
            GetConnection();

            return Task.Run(() =>
            {
                SqlDataReader reader = GetDataReaderNoConnection(query) as SqlDataReader;

                try
                {
                    T instance = (T)Activator.CreateInstance(typeof(T));

                    reader.Read();

                    var props = typeof(T).GetProperties();

                    foreach (PropertyInfo inf in props)
                    {
                        if (HasColumn(reader, inf.Name))
                        {
                            inf.SetValue(instance, Util.IsNull(reader[inf.Name]) ? null : Util.GetProperty(reader[inf.Name], inf.PropertyType));
                        }
                    }

                    return instance;

                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (!reader.IsClosed)
                        reader.Close();

                    Close();
                }
            });
        }
        /// <summary>
        /// Asynchronously executes a sql select Command and returns results as a desired type object.
        /// </summary>
        public Task<T> GetObjectAsync<T>(IDbCommand query)
        {
            GetConnection();

            return Task.Run(() =>
            {
                SqlDataReader reader = GetDataReaderNoConnection(query) as SqlDataReader;

                try
                {
                    T instance = (T)Activator.CreateInstance(typeof(T));

                    reader.Read();

                    var props = typeof(T).GetProperties();

                    foreach (PropertyInfo inf in props)
                    {
                        if (HasColumn(reader, inf.Name))
                        {
                            inf.SetValue(instance, Util.IsNull(reader[inf.Name]) ? null : Util.GetProperty(reader[inf.Name], inf.PropertyType));
                        }
                    }

                    return instance;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (!reader.IsClosed)
                        reader.Close();

                    Close();
                }
            });
        }
        /// <summary>
        /// Asynchronously executes a sql select query and returns results as a list of desired type objects.
        /// </summary>
        public Task<List<T>> GetObjectListAsync<T>(string query)
        {
            List<T> entityList = new List<T>();

            GetConnection();

            return Task.Run(() =>
            {
                SqlDataReader reader = GetDataReaderNoConnection(query) as SqlDataReader;

                try
                {
                    var props = typeof(T).GetProperties();

                    while (reader.Read())
                    {
                        T instance = (T)Activator.CreateInstance(typeof(T));

                        foreach (PropertyInfo inf in props)
                        {
                            if (HasColumn(reader, inf.Name))
                            {
                                inf.SetValue(instance, Util.IsNull(reader[inf.Name]) ? null : Util.GetProperty(reader[inf.Name], inf.PropertyType));
                            }
                        }

                        entityList.Add(instance);
                    }

                    return entityList;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (!reader.IsClosed)
                        reader.Close();

                    Close();
                }
            });
        }
        /// <summary>
        /// Asynchronously executes a sql select Command and returns results as a list of desired type objects.
        /// </summary>
        public Task<List<T>> GetObjectListAsync<T>(IDbCommand query)
        {
            List<T> entityList = new List<T>();

            GetConnection();

            return Task.Run(() =>
            {
                SqlDataReader reader = GetDataReaderNoConnection(query) as SqlDataReader;

                try
                {
                    var props = typeof(T).GetProperties();

                    while (reader.Read())
                    {
                        T instance = (T)Activator.CreateInstance(typeof(T));

                        foreach (PropertyInfo inf in props)
                        {
                            if (HasColumn(reader, inf.Name))
                            {
                                inf.SetValue(instance, Util.IsNull(reader[inf.Name]) ? null : Util.GetProperty(reader[inf.Name], inf.PropertyType));
                            }
                        }

                        entityList.Add(instance);
                    }

                    return entityList;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (!reader.IsClosed)
                        reader.Close();

                    Close();
                }
            });
        }
        /// <summary>
        /// Asynchronously executes a sql select query and returns results result as a single value.
        /// </summary>
        public Task<object> GetSingleValueAsync(string query)
        {
            SqlCommand Command = null;
            try
            {
                GetConnection();
                Command = new SqlCommand(query, myCon as SqlConnection, tran as SqlTransaction);
                return Task.Run(() => { return Command.ExecuteScalar(); });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// Asynchronously executes a sql select Command and returns results result as a single value.
        /// </summary>
        public Task<object> GetSingleValueAsync(IDbCommand query)
        {
            try
            {
                GetConnection();
                query.Transaction = tran;
                query.Connection = myCon;
                return Task.Run(() => { return query.ExecuteScalar(); });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }

        private IDataReader GetDataReaderNoConnection(string query)
        {
            SqlCommand command = null;

            try
            {
                command = new SqlCommand(query, myCon as SqlConnection, tran as SqlTransaction);
                return command.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private IDataReader GetDataReaderNoConnection(IDbCommand query)
        {
            try
            {
                query.Transaction = tran;
                query.Connection = myCon;
                return query.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
