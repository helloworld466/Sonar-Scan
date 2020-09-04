using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentACar.Data.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly string _connectionString;
        private IDbConnection _objConnection;

        public Repository()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; 
        }

        public void Dispose()
        {
            if (_objConnection != null && _objConnection.State == ConnectionState.Open)
                _objConnection.Close();
        }

        public IDbConnection Connection
        {
            get
            {
                if (_objConnection == null)
                    _objConnection = new System.Data.SqlClient.SqlConnection(_connectionString);
                if (_objConnection.State != ConnectionState.Open)
                    _objConnection.Open();
                return _objConnection;
            }
        }

        public IEnumerable<T> ExecuteSelect(string sql, object param, CommandType? commandType = default(CommandType?))
        {
            using (DapperWrapper objWrap = new DapperWrapper(Connection))
            {
                return objWrap.ExecuteEnumerable<T>(sql, param, commandType);
            }
        }

        public IEnumerable<dynamic> ExecuteSelectDynamic(string sql, object param, CommandType? commandType = default(CommandType?))
        {
            using (DapperWrapper objWrap = new DapperWrapper(Connection))
            {
                return objWrap.ExecuteEnumerable<dynamic>(sql, param, commandType);
            }
        }

        public int ExecuteNonQuery(string sql, object param, CommandType? commandType = default(CommandType?))
        {
            using (DapperWrapper objWrap = new DapperWrapper(Connection))
            {
                return objWrap.ExecuteNonQuery(sql, param, commandType);
            }
        }

        public object ExecuteScalar(string sql, object param, CommandType? commandType = default(CommandType?))
        {
            using (DapperWrapper objWrap = new DapperWrapper(Connection))
            {
                return objWrap.ExecuteScalar(sql, param, commandType);
            }
        }

        public Dapper.SqlMapper.GridReader ExecuteQueryMultiple(string sql, object param, CommandType? commandType = default(CommandType?))
        {
            using (DapperWrapper objWrap = new DapperWrapper(Connection))
            {
                return objWrap.ExecuteQueryMultiple(sql, param, commandType);
            }
        }

        //public IEnumerable<T> SelectAll()
        //{
        //    return Conn.Query<T>("SELECT * FROM " + _tableName);
        //}

        //public virtual IEnumerable<T> SelectAll(IDbTransaction transaction = null, int? commandTimeout = null)
        //{
        //    return Conn.GetAll<T>(transaction: transaction, commandTimeout: commandTimeout);
        //}

        //public virtual IEnumerable<T> GetBy(object where = null, object order = null, IDbTransaction transaction = null, int? commandTimeout = null)
        //{
        //    return Conn.GetBy<T>(where: where, order: order, transaction: transaction, commandTimeout: commandTimeout);
        //}

        //public IEnumerable<TSp> Exec<TSp>(TRepoQuery repoQuery, DynamicParameters param = null, IDbTransaction transaction = null,
        //                                      int? commandTimeout = null)
        //{
        //    return Conn.Query<TSp>(repoQuery.Value, param, commandType: repoQuery.CmdType, transaction: transaction, commandTimeout: commandTimeout);
        //}

        //public void Exec(TRepoQuery repoQuery, DynamicParameters param = null, IDbTransaction transaction = null,
        //                          int? commandTimeout = null)
        //{
        //    Conn.Execute(repoQuery.Value, param, commandType: repoQuery.CmdType, transaction: transaction, commandTimeout: commandTimeout);
        //}
    }
}
