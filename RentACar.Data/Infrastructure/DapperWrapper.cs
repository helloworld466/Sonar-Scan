using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace RentACar.Data.Infrastructure
{
    public class DapperWrapper : IDapperWrapper
    {
        readonly IDbConnection _dbConnection;

        public DapperWrapper(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int ExecuteNonQuery(string sql,  object param = null, CommandType? commandType = default(CommandType?))
        {
            return _dbConnection.Execute(sql, param, commandType: commandType);
        }

        public IEnumerable<dynamic> ExecuteEnumerable(string sql, object param = null, CommandType? commandType = default(CommandType?))
        {
            return _dbConnection.Query(sql, param, commandType: commandType);
        }

        public IEnumerable<T> ExecuteEnumerable<T>(string sql, object param = null, CommandType? commandType = default(CommandType?))
        {
            return _dbConnection.Query<T>(sql, param, commandType: commandType);
        }

        public object ExecuteScalar(string sql, object param = null, CommandType? commandType = default(CommandType?))
        {
            return _dbConnection.ExecuteScalar(sql, param, null, null, commandType: commandType);
        }

        public SqlMapper.GridReader ExecuteQueryMultiple(string sql, object param = null, CommandType? commandType = default(CommandType?))
        {
            return _dbConnection.QueryMultiple(sql, param, null, null, commandType: commandType);
        }

        public void Dispose()
        {
            //_dbConnection.Dispose();
        }
    }
}
