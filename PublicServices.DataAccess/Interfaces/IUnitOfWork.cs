using PublicServices.Core.Entities;
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
        IRepository<HistorialCrediticio> HistorialCrediticioRepository { get; }
        IRepository<IndiceInflacion> IndiceInflacionRepository { get; }
        IRepository<Moneda> MonedaRepository { get; }
        IRepository<TasaCambiaria> TasaCambiariaRepository { get; }
        IRepository<RequestLog> RequestLogRepository { get; }

    }
}
