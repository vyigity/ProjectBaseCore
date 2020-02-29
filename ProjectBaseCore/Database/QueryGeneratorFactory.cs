﻿using ProjectBaseCore.AppContext;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBaseCore.Database
{
    public static class QueryGeneratorFactory
    {
        /// <summary>
        /// Instantiates a new encapsulated QueryGenerator object.
        /// </summary>
        public static IQueryGenerator GetDbObject()
        {
            string conStr = AppContext2.GetConnectionString(AppContext2.DEFAULT_DB);
            string providerName = AppContext2.AppSettings[string.Format("{0}ProviderName", AppContext2.DEFAULT_DB)];

            if (providerName == "Oracle.ManagedDataAccess.Client")
            {
                return new OracleManagedQueryGenerator();
            }
            else if (providerName == "System.Data.SqlClient")
            {
                return new SqlQueryGenerator();
            }
            else if (providerName == "MySql.Data.MySqlClient")
            {
                return new MySqlQueryGenerator();
            }
            else if (providerName == "Npgsql")
            {
                return new NpgsqlQueryGenerator();
            }
            else
                throw new Exception("Provider is not recognized.");
        }

        /// <summary>
        /// Instantiates a new encapsulated QueryGenerator object with parameter processing mode.
        /// </summary>
        public static IQueryGenerator GetDbObject(ParameterMode ParameterProcessingMode)
        {
            string conStr = AppContext2.GetConnectionString(AppContext2.DEFAULT_DB);
            string providerName = AppContext2.AppSettings[string.Format("{0}ProviderName", AppContext2.DEFAULT_DB)];

            if (providerName == "Oracle.ManagedDataAccess.Client")
            {
                return new OracleManagedQueryGenerator(ParameterProcessingMode);
            }
            else if (providerName == "System.Data.SqlClient")
            {
                return new SqlQueryGenerator(ParameterProcessingMode);
            }
            else if (providerName == "MySql.Data.MySqlClient")
            {
                return new MySqlQueryGenerator(ParameterProcessingMode);
            }
            else if (providerName == "Npgsql")
            {
                return new NpgsqlQueryGenerator(ParameterProcessingMode);
            }
            else
                throw new Exception("Provider is not recognized.");
        }
    }
}
