using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBaseCore.Database
{
    public class QueryGeneratorFactory : IQueryGeneratorFactory
    {
        private readonly IConfiguration configuration;
        public QueryGeneratorFactory(IConfiguration configuration)
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
        /// Instantiates a new encapsulated QueryGenerator object.
        /// </summary>
        public IQueryGenerator GetDbObject()
        {
            string providerName = GetProviderName();

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
        /// Instantiates a new encapsulated QueryGenerator object with provider.
        /// </summary>
        public IQueryGenerator GetDbObject(Provider provider)
        {
            if (provider == Provider.OracleManagedDataAccess)
            {
                return new OracleManagedQueryGenerator();
            }
            else if (provider == Provider.SqlServer)
            {
                return new SqlQueryGenerator();
            }
            else if (provider == Provider.MySql)
            {
                return new MySqlQueryGenerator();
            }
            else if (provider == Provider.Npgsql)
            {
                return new NpgsqlQueryGenerator();
            }
            else
                throw new Exception("Provider is not recognized.");
        }

        /// <summary>
        /// Instantiates a new encapsulated QueryGenerator object with parameter processing mode.
        /// </summary>
        public IQueryGenerator GetDbObject(ParameterMode ParameterProcessingMode)
        {
            string providerName = GetProviderName();

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
        /// <summary>
        /// Instantiates a new encapsulated QueryGenerator object with provider and parameter processing mode.
        /// </summary>
        public IQueryGenerator GetDbObject(Provider provider, ParameterMode ParameterProcessingMode)
        {
            if (provider == Provider.OracleManagedDataAccess)
            {
                return new OracleManagedQueryGenerator(ParameterProcessingMode);
            }
            else if (provider == Provider.SqlServer)
            {
                return new SqlQueryGenerator(ParameterProcessingMode);
            }
            else if (provider == Provider.MySql)
            {
                return new MySqlQueryGenerator(ParameterProcessingMode);
            }
            else if (provider == Provider.Npgsql)
            {
                return new NpgsqlQueryGenerator(ParameterProcessingMode);
            }
            else
                throw new Exception("Provider is not recognized.");
        }
    }
}
