﻿using System.Data;

namespace ProjectBaseCore.Database
{
    /// <summary>
    /// Can be used for database Command generation with helper functions.
    /// </summary>
    public interface IQueryGenerator
    {
        /// <summary>
        /// Query generator will use this string as table name while generating update and insert statements.
        /// </summary>
        string TableName { get; set; }  
        /// <summary>
        /// Query generator will use this string as main sql query text. It can be used for any kind of Command like DML and DDL. It can be used mainly for a select query.
        /// </summary>
        string SelectText { get; set; }
        /// <summary>
        /// Query generator will concate this string to end of query. String must include sql key word like WHERE. For parameter usage in query, symbols of : or @ can be used. For UPDATE generation, this must be used for specify filter text.
        /// </summary>
        string FilterText { get; set; }
        /// <summary>
        /// Query generator will concate this string to end of query. It can be used for group by expressions.
        /// </summary>
        string SelectTail { get; set; }
        /// <summary>
        /// Query generator will use this string as procedure name. It can be a database function or procedure.
        /// </summary>
        string ProcedureName { get; set; }

        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        void AddFilterParameter(string parameterName, object value);
        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        void AddFilterParameter(string parameterName, object value, ParameterDirection direction);
        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        void AddFilterParameter(string parameterName, object dbType, object value, ParameterDirection direction);
        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        void AddFilterParameter(string parameterName, object value, int size, ParameterDirection direction);
        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        void AddFilterParameter(string parameterName, object value, int size, byte scale, byte precision, ParameterDirection direction);
        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        void AddFilterParameter(string parameterName, object dbType, object value, int size, ParameterDirection direction);
        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        void AddFilterParameter(string parameterName, object dbType, object value, int size, byte scale, byte precision, ParameterDirection direction);
        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        void AddFilterParameter(string parameterName, DbType dbType, object value, int size, ParameterDirection direction);
        /// <summary>
        /// Query generator will use this parameter for non-generated sql statement that is given with FilterText property.
        /// </summary>
        void AddFilterParameter(string parameterName, DbType dbType, object value, int size, byte scale, byte precision, ParameterDirection direction);

        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        void AddDataParameter(string parameterName, object value);
        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        void AddDataParameter(string parameterName, object value, ParameterDirection direction);
        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        void AddDataParameter(string parameterName, object dbType, object value, ParameterDirection direction);
        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        void AddDataParameter(string parameterName, object value, int size, ParameterDirection direction);
        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        void AddDataParameter(string parameterName, object value, int size, byte scale, byte precision, ParameterDirection direction);
        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        void AddDataParameter(string parameterName, object dbType, object value, int size, ParameterDirection direction);
        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        void AddDataParameter(string parameterName, object dbType, object value, int size, byte scale, byte precision, ParameterDirection direction);
        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        void AddDataParameter(string parameterName, DbType dbType, object value, int size, ParameterDirection direction);
        /// <summary>
        /// Query generator will use this parameter while generating update and insert statements or procedure calls. For statement generation, parameter name must be same with column name in database table.
        /// </summary>
        void AddDataParameter(string parameterName, DbType dbType, object value, int size, byte scale, byte precision, ParameterDirection direction);     

        /// <summary>
        /// Returns a database returned parameter.
        /// </summary>
        object GetParameterValue(string parameterName);
        /// <summary>
        /// Returns generated insert Command.
        /// </summary>
        IDbCommand GetInsertCommand();
        /// <summary>
        /// Returns generated update Command.
        /// </summary>
        IDbCommand GetUpdateCommand();
        /// <summary>
        /// Returns generated general Command.
        /// </summary>
        IDbCommand GetSelectCommandBasic();       
        /// <summary>
        /// Returns generated procedure Command.
        /// </summary>
        IDbCommand GetProcedure();
        /// <summary>
        /// Clears all query generator instance.
        /// </summary>
        void Clear();
    }
}