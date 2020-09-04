using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IRepository<TSet> GetRepository<TSet>() where TSet : class
        {
            IRepository<TSet> repository;
            {
                repository = new Repository<TSet>();
            }
            return repository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
