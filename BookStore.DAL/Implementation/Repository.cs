using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Context;
using BookStore.DAL.Interface;
using System.Linq.Expressions;
using System.Data.Entity;

namespace BookStore.DAL.Implementation
{
    public class Repository<T> where T : class
    {
        #region properties

        private BookStoreContext dataContext;
        private readonly DbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected BookStoreContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        #endregion

        protected Repository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();

        }

        #region Implementation

        //protected virtual void All(T entity)
        //{
        //    dbSet.All(entity);
        //}
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            //dataContext.Configuration.AutoDetectChangesEnabled = false;
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;

        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {

            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(object id)
        {
            return dbSet.Find(id);
        }
        public virtual IEnumerable<T> GetAllNonAsync()
        {
            return dbSet.ToList();
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async virtual Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> where)
        {
            return await dbSet.Where(where).ToListAsync();
        }
        public virtual IEnumerable<T> GetManyNonAsync(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public async Task<T> Get(Expression<Func<T, bool>> where)
        {
            if (where != null)
                return await dbSet.Where(where).FirstOrDefaultAsync<T>();
            else
                return await dbSet.SingleOrDefaultAsync();
        }
        public T GetNonAsync(Expression<Func<T, bool>> where)
        {
            if (where != null)
                return dbSet.Where(where).FirstOrDefault<T>();
            else
                return dbSet.SingleOrDefault();
        }

        public virtual IEnumerable<T> ExecuteStoredProcedure(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters);

        }

        #endregion



    }
}
