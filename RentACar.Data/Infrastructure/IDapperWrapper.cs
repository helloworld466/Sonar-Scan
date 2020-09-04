using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.Infrastructure
{
    public interface IDapperWrapper : IDisposable
    {
        int ExecuteNonQuery(string sql,  object param = null, CommandType? commandType = default(CommandType?));
        IEnumerable<dynamic> ExecuteEnumerable(string sql, object param = null, CommandType? commandType = default(CommandType?));
        IEnumerable<T> ExecuteEnumerable<T>(string sql, object param = null, CommandType? commandType = default(CommandType?));
        object ExecuteScalar(string sql, object param = null, CommandType? commandType = default(CommandType?));
        Dapper.SqlMapper.GridReader ExecuteQueryMultiple(string sql, object param = null, CommandType? commandType = default(CommandType?));
    }
}
