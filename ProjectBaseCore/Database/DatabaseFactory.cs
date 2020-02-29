﻿using ProjectBaseCore.AppContext;
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

    public static class DatabaseFactory
    {
        /// <summary>
        /// Instantiates a new encapsulated database interaction object.
        /// </summary>
        public static IDatabase2 GetDbObject()
        {
            string conStr = AppContext2.GetConnectionString(AppContext2.DEFAULT_DB);
            string providerName = AppContext2.AppSettings[string.Format("{0}ProviderName", AppContext2.DEFAULT_DB)];

            //if (conStr.ProviderName == "Oracle.DataAccess.Client")
            //{
            //    return new OracleDatabase2();
            //}
            if (providerName == "Oracle.ManagedDataAccess.Client")
            {
                return new OracleManagedDatabase2();
            }
            else if (providerName == "System.Data.SqlClient")
            {
                return new SqlDatabase2();
            }
            else if (providerName == "MySql.Data.MySqlClient")
            {
                return new MySqlDatabase2();
            }
            else if (providerName == "System.Data.OleDb")
            {
                return new OleDbDatabase2();
            }
            else if (providerName == "Npgsql")
            {
                return new NpgsqlDatabase2();
            }
            else
                throw new Exception("Provider is not recognized.");
        }
        /// <summary>
        /// Instantiates a new encapsulated database interaction object according to database setting.
        /// </summary>
        public static IDatabase2 GetDbObject(DbSettings setting)
        {
            string conStr = AppContext2.GetConnectionString(AppContext2.DEFAULT_DB);
            string providerName = AppContext2.AppSettings[string.Format("{0}ProviderName", AppContext2.DEFAULT_DB)];
  
            if (providerName == "Oracle.ManagedDataAccess.Client")
            {
                return new OracleManagedDatabase2(setting);
            }
            else if (providerName == "System.Data.SqlClient")
            {
                return new SqlDatabase2(setting);
            }
            else if (providerName == "MySql.Data.MySqlClient")
            {
                return new MySqlDatabase2(setting);
            }
            else if (providerName == "System.Data.OleDb")
            {
                return new OleDbDatabase2(setting);
            }
            else if (providerName == "Npgsql")
            {
                return new NpgsqlDatabase2(setting);
            }
            else
                throw new Exception("Provider is not recognized.");
        }
        /// <summary>
        /// Instantiates a new encapsulated database interaction object according to database setting and transaction isolation.
        /// </summary>
        public static IDatabase2 GetDbObject(DbSettings setting, IsolationLevel isolation)
        {
            string conStr = AppContext2.GetConnectionString(AppContext2.DEFAULT_DB);
            string providerName = AppContext2.AppSettings[string.Format("{0}ProviderName", AppContext2.DEFAULT_DB)];

            if (providerName == "Oracle.ManagedDataAccess.Client")
            {
                return new OracleManagedDatabase2(setting, isolation);
            }
            else if (providerName == "System.Data.SqlClient")
            {
                return new SqlDatabase2(setting, isolation);
            }
            else if (providerName == "MySql.Data.MySqlClient")
            {
                return new MySqlDatabase2(setting, isolation);
            }
            else if (providerName == "System.Data.OleDb")
            {
                return new OleDbDatabase2(setting, isolation);
            }
            else if (providerName == "Npgsql")
            {
                return new NpgsqlDatabase2(setting, isolation);
            }
            else
                throw new Exception("Provider is not recognized.");
        }

        /// <summary>
        /// Instantiates a new encapsulated asynchronous database interaction object.
        /// </summary>
        public static IDatabaseAsync2 GetDbObjectAsync()
        {
            return GetDbObject() as IDatabaseAsync2;
        }
        /// <summary>
        /// Instantiates a new encapsulated asynchronous database interaction object according to database setting.
        /// </summary>
        public static IDatabaseAsync2 GetDbObjectAsync(DbSettings setting)
        {
            return GetDbObject(setting) as IDatabaseAsync2;
        }
        /// <summary>
        /// Instantiates a new encapsulated asynchronous database interaction object according to database setting and transaction isolation.
        /// </summary>
        public static IDatabaseAsync2 GetDbObjectAsync(DbSettings setting, IsolationLevel isolation)
        {
            return GetDbObject(setting, isolation) as IDatabaseAsync2;
        }
    }
}