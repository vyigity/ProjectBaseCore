﻿ProjectBaseCore
ProjectBase (PB) is a Utility and Data Access library. PB designed with a database independent interface oriented approach to ensure extentibility and reliablity. PB's codes can be changed or manipulated easily.

* appsettings.json file must be configured as below

{
  "DEFAULT_DB": "Context",
  "ContextProviderName": "System.Data.SqlClient",
  "ConnectionStrings": {
    "Context": "Server=MyServer;Database=MyDb1;User Id=TestUser;Password=TestPswd;MultipleActiveResultSets=true"
  }
}

* Provider names can be set as followings
Oracle: Oracle.ManagedDataAccess.Client
Sql Server: System.Data.SqlClient
MySql: MySql.Data.MySqlClient
OleDb: System.Data.OleDb
Postgre: Npgsql

* Provider names must be formatted like "{ConnectionStringName}ProviderName"


PB has 3 type of data access:

Automatic Connection Management: Using single connection object and while executing a command, connection is opened and closed automatically.
Manuel Connection Management: Using single connection object and connection is opened and closed by developer manually.
Transaction Mode: PB supports PL/SQL type code writing of transactional processes. PB creates transactions and manages them automatically.
PB currently supports Oracle (Managed-Unmanaged Provider), SQL Server databases and OleDb. PB supports MySql provider with v2.0.0 and PostgreSQL with v3.0.0.

PB supports asynchronous programming with v4.0.0-beta.

Also PB supports low level object mapping features.

For introduction:

http://vyigity.blogspot.com.tr/2017/10/veri-erisim-katmanna-giris-introduction.html

For connection management examples:

http://vyigity.blogspot.com.tr/2017/10/projectbase-ile-veri-taban-baglant.html

For transactions examples:

http://vyigity.blogspot.com.tr/2017/10/projectbase-ile-veri-taban-islemleri.html

For DML examples:

http://vyigity.blogspot.com.tr/2017/10/projectbase-ile-querygenerator.html

For parametric database procedures and functions examples:

http://vyigity.blogspot.com.tr/2017/10/projectbase-ve-querygenertor-ile-veri.html

For typed data selection using objects examples:

http://vyigity.blogspot.com.tr/2017/10/projectbase-ile-datatable-yerine-nesne.html

For global parameter usage examples:

http://vyigity.blogspot.com.tr/2017/12/projectbase-kutuphanesi-ile-evrensel.html

For asynchronous programming examples:

http://vyigity.blogspot.com.tr/2018/03/projectbase-pb-ile-asenkron-programlama.html