using System.Data;

namespace ProjectBaseCore.Database
{
    public interface IDatabaseFactory
    {
        IDatabase2 GetDbObject();
        IDatabase2 GetDbObject(DbSettings setting);
        IDatabase2 GetDbObject(DbSettings setting, IsolationLevel isolation);
        IDatabase2 GetDbObject(Provider provider);
        IDatabase2 GetDbObject(Provider provider, DbSettings setting);
        IDatabase2 GetDbObject(Provider provider, DbSettings setting, IsolationLevel isolation);
        IDatabaseAsync2 GetDbObjectAsync();
        IDatabaseAsync2 GetDbObjectAsync(DbSettings setting);
        IDatabaseAsync2 GetDbObjectAsync(DbSettings setting, IsolationLevel isolation);
        IDatabaseAsync2 GetDbObjectAsync(Provider provider);
        IDatabaseAsync2 GetDbObjectAsync(Provider provider, DbSettings setting);
        IDatabaseAsync2 GetDbObjectAsync(Provider provider, DbSettings setting, IsolationLevel isolation);
    }
}