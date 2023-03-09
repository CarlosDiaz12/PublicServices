using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicServices.DataAccess.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        void SaveChanges();
        Task<int> SaveChangesAsync();
        //IRepository<Order> OrderRepository { get; }

    }
}
