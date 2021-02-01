# ProjectBaseCore

ProjectBaseCore (PBCore) is a Utility and Data Access library. PBCore designed with a database independent interface oriented approach to ensure extentibility and reliablity. PBCore's codes can be changed or manipulated easily.

PBCore has 3 type of data access: 

* Automatic Connection Management: Uses single connection object and while executing a command, connection is opened and closed automatically.
* Manuel Connection Management: Uses single connection object and connection is opened and closed by developer manually.
* Transaction Mode: PBCore supports PL/SQL type code writing of transactional processes. PBCore creates transactions and manages them automatically.

PBCore currently supports Oracle (Managed Provider), SQL Server, OleDb, MySql and PostgreSQL.

PBCore supports asynchronous programming.

Also PBCore supports low level object mapping features.

If you use appsetting.json file, file must include following sections:

  1. DefaultDb: Connectionstring name to connect. Connection string is placed under ConnectionStrings section. For example: Context.

  2. {DefaultDb}ProviderName: Provider to use. For example, section name can be ContextProviderName for Context named connection string. Can be set followings:

      * Oracle.ManagedDataAccess.Client
      * System.Data.SqlClient
      * MySql.Data.MySqlClient
      * System.Data.OleDb
      * Npgsql

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


