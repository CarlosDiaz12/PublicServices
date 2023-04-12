using PublicServices.Core.Entities;
using PublicServices.DataAccess.Data;
using PublicServices.DataAccess.Interfaces;
using PublicServices.DataAccess.Repositories.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PublicServices.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRepository<HistorialCrediticio> HistorialCrediticioRepository { get; }
        public IRepository<IndiceInflacion> IndiceInflacionRepository { get; }
        public IRepository<Moneda> MonedaRepository { get; }
        public IRepository<TasaCambiaria> TasaCambiariaRepository { get; }
        public IRepository<RequestLog> RequestLogRepository { get; }
        public UnitOfWork(
            AppDbContext context,
             IRepository<HistorialCrediticio> historialCrediticioRepository,
             IRepository<IndiceInflacion> indiceInflacionRepository,
             IRepository<Moneda> monedaRepository,
             IRepository<TasaCambiaria> tasaCambiariaRepository,
             IRepository<RequestLog> requestLogRepository)
        {
            _context = context;
            HistorialCrediticioRepository = historialCrediticioRepository;
            IndiceInflacionRepository = indiceInflacionRepository;
            MonedaRepository = monedaRepository;
            TasaCambiariaRepository = tasaCambiariaRepository;
            RequestLogRepository = requestLogRepository;
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var repositoryProperty = this.GetType().GetProperties().FirstOrDefault(x => x.PropertyType.GenericTypeArguments.FirstOrDefault() == typeof(T));
            if (repositoryProperty == null) return new BaseQueryRepository<T>(this._context);
            return repositoryProperty.GetValue(this) as IRepository<T>;
        }

    }
}
