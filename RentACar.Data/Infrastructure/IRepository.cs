using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.Infrastructure
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> ExecuteSelect(string sql, object param, CommandType? commandType = default(CommandType?));
        IEnumerable<dynamic> ExecuteSelectDynamic(string sql, object param, CommandType? commandType = default(CommandType?));
        int ExecuteNonQuery(string sql, object param, CommandType? commandType = default(CommandType?));
        object ExecuteScalar(string sql, object param, CommandType? commandType = default(CommandType?));
        Dapper.SqlMapper.GridReader ExecuteQueryMultiple(string sql, object param, CommandType? commandType = default(CommandType?));
        void Dispose();
        
        //IEnumerable<T> GetBy(object where = null, object order = null, IDbTransaction transaction = null, int? commandTimeout = null);
        //IEnumerable<TSp> Exec<TSp>(TRepoQuery repoQuery, DynamicParameters param = null, IDbTransaction transaction = null, int? commandTimeout = null);
        //void Exec(TRepoQuery repoQuery, DynamicParameters param = null, IDbTransaction transaction = null, int? commandTimeout = null);
    }
}
