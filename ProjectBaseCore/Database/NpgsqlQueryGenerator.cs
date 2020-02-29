﻿using Npgsql;
using NpgsqlTypes;
using ProjectBaseCore.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBaseCore.Database
{
    /// <summary>
    /// Can be used for database Command generation with helper functions.
    /// </summary>
    public class NpgsqlQueryGenerator : QueryGeneratorBase,IQueryGenerator
    {
        List<NpgsqlParameter> DataParameters;
        List<NpgsqlParameter> FilterParameters;
        bool isFilled = false;
        NpgsqlCommand Command = new NpgsqlCommand();

        public NpgsqlQueryGenerator() : base('@')
        {
            DataParameters = new List<NpgsqlParameter>();
            FilterParameters = new List<NpgsqlParameter>();
        }

        public NpgsqlQueryGenerator(ParameterMode ParameterProcessingMode) : base('@')
        {
            DataParameters = new List<NpgsqlParameter>();
            FilterParameters = new List<NpgsqlParameter>();
            this.ParameterProcessingMode = ParameterProcessingMode;
        }

        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        public override void AddFilterParameter(string parameterName, object value)
        {
            FilterParameters.Add(new NpgsqlParameter(parameterName, value));
        }
        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        public override void AddFilterParameter(string parameterName, object value, ParameterDirection direction)
        {
            NpgsqlParameter param = new NpgsqlParameter(parameterName, value);
            param.Direction = direction;
            FilterParameters.Add(param);
        }
        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        public override void AddFilterParameter(string parameterName, object value, int size, ParameterDirection direction)
        {
            NpgsqlParameter param = new NpgsqlParameter(parameterName, value);
            param.Direction = direction;
            param.Size = size;
            FilterParameters.Add(param);
        }
        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        public override void AddFilterParameter(string parameterName, object value, int size, byte scale, byte precision, ParameterDirection direction)
        {
            NpgsqlParameter param = new NpgsqlParameter(parameterName, value);
            param.Direction = direction;
            param.Size = size;
            param.Scale = scale;
            param.Precision = precision;
            FilterParameters.Add(param);
        }
        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        public override void AddFilterParameter(string parameterName, object dbBaseDbType, object value, ParameterDirection direction)
        {
            NpgsqlParameter param = new NpgsqlParameter(parameterName, value);
            param.Direction = direction;
            param.NpgsqlDbType = (NpgsqlDbType)dbBaseDbType;
            FilterParameters.Add(param);
        }
        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        public override void AddFilterParameter(string parameterName, object dbBaseDbType, object value, int size, ParameterDirection direction)
        {
            NpgsqlParameter param = new NpgsqlParameter(parameterName, value);
            param.Direction = direction;
            param.Size = size;
            param.NpgsqlDbType = (NpgsqlDbType)dbBaseDbType;
            FilterParameters.Add(param);
        }
        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        public override void AddFilterParameter(string parameterName, object dbBaseDbType, object value, int size, byte scale, byte precision, ParameterDirection direction)
        {
            NpgsqlParameter param = new NpgsqlParameter(parameterName, value);
            param.Direction = direction;
            param.Size = size;
            param.Scale = scale;
            param.Precision = precision;
            param.NpgsqlDbType = (NpgsqlDbType)dbBaseDbType;
            FilterParameters.Add(param);
        }
        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        public override void AddFilterParameter(string parameterName, DbType dbType, object value, int size, ParameterDirection direction)
        {
            NpgsqlParameter param = new NpgsqlParameter(parameterName, value);
            param.Direction = direction;
            param.Size = size;
            param.DbType = dbType;
            FilterParameters.Add(param);
        }
        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        public override void AddFilterParameter(string parameterName, DbType dbType, object value, int size, byte scale, byte precision, ParameterDirection direction)
        {
            NpgsqlParameter param = new NpgsqlParameter(parameterName, value);
            param.Direction = direction;
            param.Size = size;
            param.Scale = scale;
            param.Precision = precision;
            param.DbType = dbType;
            FilterParameters.Add(param);
        }

        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        public override void AddDataParameter(string parameterName, object value)
        {
            DataParameters.Add(new NpgsqlParameter(parameterName, value));
        }
        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        public override void AddDataParameter(string parameterName, object value, ParameterDirection direction)
        {
            NpgsqlParameter param = new NpgsqlParameter(parameterName, value);
            param.Direction = direction;
            DataParameters.Add(param);
        }
        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        public override void AddDataParameter(string parameterName, object value, int size, ParameterDirection direction)
        {
            NpgsqlParameter param = new NpgsqlParameter(parameterName, value);
            param.Direction = direction;
            param.Size = size;
            DataParameters.Add(param);
        }
        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        public override void AddDataParameter(string parameterName, object value, int size, byte scale, byte precision, ParameterDirection direction)
        {
            NpgsqlParameter param = new NpgsqlParameter(parameterName, value);
            param.Direction = direction;
            param.Size = size;
            param.Scale = scale;
            param.Precision = precision;
            DataParameters.Add(param);
        }
        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        public override void AddDataParameter(string parameterName, object dbBaseDbType, object value, ParameterDirection direction)
        {
            NpgsqlParameter param = new NpgsqlParameter(parameterName, value);
            param.Direction = direction;
            param.NpgsqlDbType = (NpgsqlDbType)dbBaseDbType;
            DataParameters.Add(param);
        }
        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        public override void AddDataParameter(string parameterName, object dbBaseDbType, object value, int size, ParameterDirection direction)
        {
            NpgsqlParameter param = new NpgsqlParameter(parameterName, value);
            param.Direction = direction;
            param.Size = size;
            param.NpgsqlDbType = (NpgsqlDbType)dbBaseDbType;
            DataParameters.Add(param);
        }
        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        public override void AddDataParameter(string parameterName, object dbBaseDbType, object value, int size, byte scale, byte precision, ParameterDirection direction)
        {
            NpgsqlParameter param = new NpgsqlParameter(parameterName, value);
            param.Direction = direction;
            param.Size = size;
            param.Scale = scale;
            param.Precision = precision;
            param.NpgsqlDbType = (NpgsqlDbType)dbBaseDbType;
            DataParameters.Add(param);
        }
        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        public override void AddDataParameter(string parameterName, DbType dbType, object value, int size, ParameterDirection direction)
        {
            NpgsqlParameter param = new NpgsqlParameter(parameterName, value);
            param.Direction = direction;
            param.Size = size;
            param.DbType = dbType;
            DataParameters.Add(param);
        }
        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        public override void AddDataParameter(string parameterName, DbType dbType, object value, int size, byte scale, byte precision, ParameterDirection direction)
        {
            NpgsqlParameter param = new NpgsqlParameter(parameterName, value);
            param.Direction = direction;
            param.Size = size;
            param.Scale = scale;
            param.Precision = precision;
            param.DbType = dbType;
            DataParameters.Add(param);
        }
        
        /// <summary>
        /// Returns a database returned parameter.
        /// </summary>
        public override object GetParameterValue(string parameterName)
        {
            foreach (NpgsqlParameter item in Command.Parameters)
            {
                if (item.ParameterName == parameterName)
                {
                    return item.Value;
                }
            }

            throw new KeyNotFoundException("Key not found.");
        }
        /// <summary>
        /// Returns generated insert Command.
        /// </summary>
        public override IDbCommand GetInsertCommand()
        {
            if (!isFilled)
            {
                StringBuilder bString = new StringBuilder("INSERT INTO ");
                StringBuilder dString = new StringBuilder("(");
                StringBuilder vString = new StringBuilder("(");

                foreach (NpgsqlParameter param in DataParameters)
                {
                    dString.Append("\"");
                    dString.Append(param.ParameterName);
                    dString.Append("\"");
                    dString.Append(",");

                    vString.Append(StringProcessor.DbBasedParameterCharacter);
                    vString.Append(param.ParameterName);
                    vString.Append(",");

                    Command.Parameters.Add(param);
                }

                dString.Remove(dString.Length - 1, 1);
                vString.Remove(vString.Length - 1, 1);

                dString.Append(")");
                vString.Append(")");

                bString.Append("\"");
                bString.Append(TableName);
                bString.Append("\"");

                bString.Append(dString.ToString());

                bString.Append(" VALUES ");
                bString.Append(vString);

                Command.CommandText = bString.ToString();
            }

            isFilled = true;

            return Command;
        }
        /// <summary>
        /// Returns generated update Command.
        /// </summary>
        public override IDbCommand GetUpdateCommand()
        {
            if (!isFilled)
            {
                StringBuilder bString = new StringBuilder("UPDATE ");
                bString.Append("\"");
                bString.Append(TableName);
                bString.Append("\"");
                bString.Append(" SET ");

                foreach (NpgsqlParameter param in DataParameters)
                {
                    bString.Append("\"");
                    bString.Append(param.ParameterName);
                    bString.Append("\"");
                    bString.Append("=");
                    bString.Append(StringProcessor.DbBasedParameterCharacter);
                    bString.Append(param.ParameterName);
                    bString.Append(",");

                    Command.Parameters.Add(param);
                }

                bString.Remove(bString.Length - 1, 1);

                if (FilterText != null)
                {
                    bString.Append(" ");
                    bString.Append(GetPreparedCommandString(FilterText, CommandStringType.Filter));
                }

                foreach (NpgsqlParameter param in FilterParameters)
                {
                    Command.Parameters.Add(param);
                }

                Command.CommandText = bString.ToString();
            }

            isFilled = true;

            return Command;
        }
        /// <summary>
        /// Returns generated general Command.
        /// </summary>
        public override IDbCommand GetSelectCommandBasic()
        {
            if (!isFilled)
            {
                StringBuilder bString = new StringBuilder(GetPreparedCommandString(SelectText, CommandStringType.Main));

                if (FilterText != null)
                {
                    bString.Append(" ");
                    bString.Append(GetPreparedCommandString(FilterText, CommandStringType.Filter));
                }

                foreach (NpgsqlParameter param in FilterParameters)
                {
                    Command.Parameters.Add(param);
                }

                bString.Append(" ");

                if (SelectTail != null)
                    bString.Append(GetPreparedCommandString(SelectTail, CommandStringType.Tail));


                Command.CommandText = bString.ToString();
            }

            isFilled = true;

            return Command;
        }
        /// <summary>
        /// Returns generated procedure Command.
        /// </summary>
        public override IDbCommand GetProcedure()
        {
            if (!isFilled)
            {
                foreach (NpgsqlParameter param in DataParameters)
                {
                    Command.Parameters.Add(param);
                }

                Command.CommandText = ProcedureName;
                Command.CommandType = System.Data.CommandType.StoredProcedure;
            }

            isFilled = true;

            return Command;
        }
        /// <summary>
        /// Clears all query generator instance.
        /// </summary>
        public override void Clear()
        {
            if (DataParameters != null)
                DataParameters.Clear();
            if (FilterParameters != null)
                FilterParameters.Clear();

            TableName = null;
            SelectText = null;
            FilterText = null;
            SelectTail = null;
            ProcedureName = null;
            Command = new NpgsqlCommand();
            isFilled = false;
        }
    }
}