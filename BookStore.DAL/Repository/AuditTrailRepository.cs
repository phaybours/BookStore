using BookStore.DAL.Interface;
using BookStore.DAL.Implementation;

namespace BookStore.DAL.Repository
{

    public class AuditTrailRepository : Repository<AuditTrail>, IAuditTrailRepository
    {
        public AuditTrailRepository(IDbFactory dbFactory) : base(dbFactory) { }

    }

    public interface IAuditTrailRepository : IRepository<AuditTrail> { }
}
