using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<TSet> GetRepository<TSet>() where TSet : class;
        //IDbTransaction BeginTransaction();
        //void Commit();
        //void Close();
    }
}
