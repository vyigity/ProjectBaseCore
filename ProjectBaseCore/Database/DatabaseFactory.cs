using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//vyigity
namespace ProjectBaseCore.Database
{
    public enum DbSettings { AutoConnectionManagement = 0, TransactionMode = 1, ManuelConnectionManagement = 2 }
    public class DatabaseFactory: IDatabaseFactory
    {
        private readonly IConfiguration configuration;
        public DatabaseFactory (IConfiguration configuration )
        {
            this.configuration = configuration;
        }
        public string GetConnectionString()
        {
            return configuration.GetConnectionString(configuration.GetSection("DefaultDb").Value);
        }
        public string GetProviderName()
        {
            return configuration.GetSection(string.Format("{0}ProviderName", configuration.GetSection("DefaultDb").Value)).Value;
        }
        /// <summary>
        /// Instantiates a new encapsulated database interaction object.
        /// </summary>
        public IDatabase2 GetDbObject()
        {
            string providerName = GetProviderName();
            string connectionString = GetConnectionString();

            if (providerName == "Oracle.ManagedDataAccess.Client")
            {
                return new OracleManagedDatabase2(connectionString);
            }
            else if (providerName == "System.Data.SqlClient")
            {
                return new SqlDatabase2(connectionString);
            }
            else if (providerName == "MySql.Data.MySqlClient")
            {
                return new MySqlDatabase2(connectionString);
            }
            else if (providerName == "System.Data.OleDb")
            {
                return new OleDbDatabase2(connectionString);
            }
            else if (providerName == "Npgsql")
            {
                return new NpgsqlDatabase2(connectionString);
            }
            else
                throw new Exception("Provider is not recognized.");
        }
        /// <summary>
        /// Instantiates a new encapsulated database interaction object according to database setting.
        /// </summary>
        public IDatabase2 GetDbObject(DbSettings setting)
        {
            string providerName = GetProviderName();
            string connectionString = GetConnectionString();

            if (providerName == "Oracle.ManagedDataAccess.Client")
            {
                return new OracleManagedDatabase2(connectionString, setting);
            }
            else if (providerName == "System.Data.SqlClient")
            {
                return new SqlDatabase2(connectionString, setting);
            }
            else if (providerName == "MySql.Data.MySqlClient")
            {
                return new MySqlDatabase2(connectionString, setting);
            }
            else if (providerName == "System.Data.OleDb")
            {
                return new OleDbDatabase2(connectionString, setting);
            }
            else if (providerName == "Npgsql")
            {
                return new NpgsqlDatabase2(connectionString, setting);
            }
            else
                throw new Exception("Provider is not recognized.");
        }
        /// <summary>
        /// Instantiates a new encapsulated database interaction object according to database setting and transaction isolation.
        /// </summary>
        public IDatabase2 GetDbObject(DbSettings setting, IsolationLevel isolation)
        {
            string providerName = GetProviderName();
            string connectionString = GetConnectionString();

            if (providerName == "Oracle.ManagedDataAccess.Client")
            {
                return new OracleManagedDatabase2(connectionString, setting, isolation);
            }
            else if (providerName == "System.Data.SqlClient")
            {
                return new SqlDatabase2(connectionString, setting, isolation);
            }
            else if (providerName == "MySql.Data.MySqlClient")
            {
                return new MySqlDatabase2(connectionString, setting, isolation);
            }
            else if (providerName == "System.Data.OleDb")
            {
                return new OleDbDatabase2(connectionString, setting, isolation);
            }
            else if (providerName == "Npgsql")
            {
                return new NpgsqlDatabase2(connectionString, setting, isolation);
            }
            else
                throw new Exception("Provider is not recognized.");
        }
        /// <summary>
        /// Instantiates a new encapsulated database interaction object according to provider.
        /// </summary>
        public IDatabase2 GetDbObject(Provider provider)
        {
            string connectionString = GetConnectionString();

            if (provider == Provider.OracleManagedDataAccess)
            {
                return new OracleManagedDatabase2(connectionString);
            }
            else if (provider == Provider.SqlServer)
            {
                return new SqlDatabase2(connectionString);
            }
            else if (provider == Provider.MySql)
            {
                return new MySqlDatabase2(connectionString);
            }
            else if (provider == Provider.OleDb)
            {
                return new OleDbDatabase2(connectionString);
            }
            else if (provider == Provider.Npgsql)
            {
                return new NpgsqlDatabase2(connectionString);
            }
            else
                throw new Exception("Provider is not recognized.");
        }
        /// <summary>
        /// Instantiates a new encapsulated database interaction object according to provider and database setting.
        /// </summary>
        public IDatabase2 GetDbObject(Provider provider, DbSettings setting)
        {
            string connectionString = GetConnectionString();

            if (provider == Provider.OracleManagedDataAccess)
            {
                return new OracleManagedDatabase2(connectionString, setting);
            }
            else if (provider == Provider.SqlServer)
            {
                return new SqlDatabase2(connectionString, setting);
            }
            else if (provider == Provider.MySql)
            {
                return new MySqlDatabase2(connectionString, setting);
            }
            else if (provider == Provider.OleDb)
            {
                return new OleDbDatabase2(connectionString, setting);
            }
            else if (provider == Provider.Npgsql)
            {
                return new NpgsqlDatabase2(connectionString, setting);
            }
            else
                throw new Exception("Provider is not recognized.");
        }
        /// <summary>
        /// Instantiates a new encapsulated database interaction object according to provider, database setting and transaction isolation.
        /// </summary>
        public IDatabase2 GetDbObject(Provider provider, DbSettings setting, IsolationLevel isolation)
        {
            string connectionString = GetConnectionString();

            if (provider == Provider.OracleManagedDataAccess)
            {
                return new OracleManagedDatabase2(connectionString, setting, isolation);
            }
            else if (provider == Provider.SqlServer)
            {
                return new SqlDatabase2(connectionString, setting, isolation);
            }
            else if (provider == Provider.MySql)
            {
                return new MySqlDatabase2(connectionString, setting, isolation);
            }
            else if (provider == Provider.OleDb)
            {
                return new OleDbDatabase2(connectionString, setting, isolation);
            }
            else if (provider == Provider.Npgsql)
            {
                return new NpgsqlDatabase2(connectionString, setting, isolation);
            }
            else
                throw new Exception("Provider is not recognized.");
        }

        public IDatabase2 GetDbObject(string connectionString)
        {
            string providerName = GetProviderName();

            if (providerName == "Oracle.ManagedDataAccess.Client")
            {
                return new OracleManagedDatabase2(connectionString);
            }
            else if (providerName == "System.Data.SqlClient")
            {
                return new SqlDatabase2(connectionString);
            }
            else if (providerName == "MySql.Data.MySqlClient")
            {
                return new MySqlDatabase2(connectionString);
            }
            else if (providerName == "System.Data.OleDb")
            {
                return new OleDbDatabase2(connectionString);
            }
            else if (providerName == "Npgsql")
            {
                return new NpgsqlDatabase2(connectionString);
            }
            else
                throw new Exception("Provider is not recognized.");
        }
        /// <summary>
        /// Instantiates a new encapsulated database interaction object according to database setting.
        /// </summary>
        public IDatabase2 GetDbObject(string connectionString, DbSettings setting)
        {
            string providerName = GetProviderName();

            if (providerName == "Oracle.ManagedDataAccess.Client")
            {
                return new OracleManagedDatabase2(connectionString, setting);
            }
            else if (providerName == "System.Data.SqlClient")
            {
                return new SqlDatabase2(connectionString, setting);
            }
            else if (providerName == "MySql.Data.MySqlClient")
            {
                return new MySqlDatabase2(connectionString, setting);
            }
            else if (providerName == "System.Data.OleDb")
            {
                return new OleDbDatabase2(connectionString, setting);
            }
            else if (providerName == "Npgsql")
            {
                return new NpgsqlDatabase2(connectionString, setting);
            }
            else
                throw new Exception("Provider is not recognized.");
        }
        /// <summary>
        /// Instantiates a new encapsulated database interaction object according to database setting and transaction isolation.
        /// </summary>
        public IDatabase2 GetDbObject(string connectionString, DbSettings setting, IsolationLevel isolation)
        {
            string providerName = GetProviderName();

            if (providerName == "Oracle.ManagedDataAccess.Client")
            {
                return new OracleManagedDatabase2(connectionString, setting, isolation);
            }
            else if (providerName == "System.Data.SqlClient")
            {
                return new SqlDatabase2(connectionString, setting, isolation);
            }
            else if (providerName == "MySql.Data.MySqlClient")
            {
                return new MySqlDatabase2(connectionString, setting, isolation);
            }
            else if (providerName == "System.Data.OleDb")
            {
                return new OleDbDatabase2(connectionString, setting, isolation);
            }
            else if (providerName == "Npgsql")
            {
                return new NpgsqlDatabase2(connectionString, setting, isolation);
            }
            else
                throw new Exception("Provider is not recognized.");
        }
        /// <summary>
        /// Instantiates a new encapsulated database interaction object according to provider.
        /// </summary>
        public IDatabase2 GetDbObject(string connectionString, Provider provider)
        {
            if (provider == Provider.OracleManagedDataAccess)
            {
                return new OracleManagedDatabase2(connectionString);
            }
            else if (provider == Provider.SqlServer)
            {
                return new SqlDatabase2(connectionString);
            }
            else if (provider == Provider.MySql)
            {
                return new MySqlDatabase2(connectionString);
            }
            else if (provider == Provider.OleDb)
            {
                return new OleDbDatabase2(connectionString);
            }
            else if (provider == Provider.Npgsql)
            {
                return new NpgsqlDatabase2(connectionString);
            }
            else
                throw new Exception("Provider is not recognized.");
        }
        /// <summary>
        /// Instantiates a new encapsulated database interaction object according to provider and database setting.
        /// </summary>
        public IDatabase2 GetDbObject(string connectionString, Provider provider, DbSettings setting)
        {
            if (provider == Provider.OracleManagedDataAccess)
            {
                return new OracleManagedDatabase2(connectionString, setting);
            }
            else if (provider == Provider.SqlServer)
            {
                return new SqlDatabase2(connectionString, setting);
            }
            else if (provider == Provider.MySql)
            {
                return new MySqlDatabase2(connectionString, setting);
            }
            else if (provider == Provider.OleDb)
            {
                return new OleDbDatabase2(connectionString, setting);
            }
            else if (provider == Provider.Npgsql)
            {
                return new NpgsqlDatabase2(connectionString, setting);
            }
            else
                throw new Exception("Provider is not recognized.");
        }
        /// <summary>
        /// Instantiates a new encapsulated database interaction object according to provider, database setting and transaction isolation.
        /// </summary>
        public IDatabase2 GetDbObject(string connectionString, Provider provider, DbSettings setting, IsolationLevel isolation)
        {
            if (provider == Provider.OracleManagedDataAccess)
            {
                return new OracleManagedDatabase2(connectionString, setting, isolation);
            }
            else if (provider == Provider.SqlServer)
            {
                return new SqlDatabase2(connectionString, setting, isolation);
            }
            else if (provider == Provider.MySql)
            {
                return new MySqlDatabase2(connectionString, setting, isolation);
            }
            else if (provider == Provider.OleDb)
            {
                return new OleDbDatabase2(connectionString, setting, isolation);
            }
            else if (provider == Provider.Npgsql)
            {
                return new NpgsqlDatabase2(connectionString, setting, isolation);
            }
            else
                throw new Exception("Provider is not recognized.");
        }


        /// <summary>
        /// Instantiates a new encapsulated asynchronous database interaction object.
        /// </summary>
        public IDatabaseAsync2 GetDbObjectAsync()
        {
            return GetDbObject() as IDatabaseAsync2;
        }
        /// <summary>
        /// Instantiates a new encapsulated asynchronous database interaction object according to database setting.
        /// </summary>
        public IDatabaseAsync2 GetDbObjectAsync(DbSettings setting)
        {
            return GetDbObject(setting) as IDatabaseAsync2;
        }
        /// <summary>
        /// Instantiates a new encapsulated asynchronous database interaction object according to database setting and transaction isolation.
        /// </summary>
        public IDatabaseAsync2 GetDbObjectAsync(DbSettings setting, IsolationLevel isolation)
        {
            return GetDbObject(setting, isolation) as IDatabaseAsync2;
        }
        /// <summary>
        /// Instantiates a new encapsulated asynchronous database interaction object according to provider.
        /// </summary>
        public IDatabaseAsync2 GetDbObjectAsync(Provider provider)
        {
            return GetDbObject(provider) as IDatabaseAsync2;
        }
        /// <summary>
        /// Instantiates a new encapsulated asynchronous database interaction object according to provider and database setting.
        /// </summary>
        public IDatabaseAsync2 GetDbObjectAsync(Provider provider, DbSettings setting)
        {
            return GetDbObject(provider, setting) as IDatabaseAsync2;
        }
        /// <summary>
        /// Instantiates a new encapsulated asynchronous database interaction object according to provider, database setting and transaction isolation.
        /// </summary>
        public IDatabaseAsync2 GetDbObjectAsync(Provider provider, DbSettings setting, IsolationLevel isolation)
        {
            return GetDbObject(provider, setting, isolation) as IDatabaseAsync2;
        }

        /// <summary>
        /// Instantiates a new encapsulated asynchronous database interaction object.
        /// </summary>
        public IDatabaseAsync2 GetDbObjectAsync(string connectionString)
        {
            return GetDbObject(connectionString) as IDatabaseAsync2;
        }
        /// <summary>
        /// Instantiates a new encapsulated asynchronous database interaction object according to database setting.
        /// </summary>
        public IDatabaseAsync2 GetDbObjectAsync(string connectionString, DbSettings setting)
        {
            return GetDbObject(connectionString, setting) as IDatabaseAsync2;
        }
        /// <summary>
        /// Instantiates a new encapsulated asynchronous database interaction object according to database setting and transaction isolation.
        /// </summary>
        public IDatabaseAsync2 GetDbObjectAsync(string connectionString, DbSettings setting, IsolationLevel isolation)
        {
            return GetDbObject(connectionString, setting, isolation) as IDatabaseAsync2;
        }
        /// <summary>
        /// Instantiates a new encapsulated asynchronous database interaction object according to provider.
        /// </summary>
        public IDatabaseAsync2 GetDbObjectAsync(string connectionString, Provider provider)
        {
            return GetDbObject(connectionString, provider) as IDatabaseAsync2;
        }
        /// <summary>
        /// Instantiates a new encapsulated asynchronous database interaction object according to provider and database setting.
        /// </summary>
        public IDatabaseAsync2 GetDbObjectAsync(string connectionString, Provider provider, DbSettings setting)
        {
            return GetDbObject(connectionString, provider, setting) as IDatabaseAsync2;
        }
        /// <summary>
        /// Instantiates a new encapsulated asynchronous database interaction object according to provider, database setting and transaction isolation.
        /// </summary>
        public IDatabaseAsync2 GetDbObjectAsync(string connectionString, Provider provider, DbSettings setting, IsolationLevel isolation)
        {
            return GetDbObject(connectionString, provider, setting, isolation) as IDatabaseAsync2;
        }
    }
}
