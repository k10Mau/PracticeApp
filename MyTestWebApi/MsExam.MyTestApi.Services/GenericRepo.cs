using MsExam.MyTestWebApi.Contracts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MsExam.MyTestApi.Services
{
    public class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> _DbSet;

        protected readonly DbContext _DbContext;

        public GenericRepository()
        {

        }

        public GenericRepository(DbContext DbContext)
        {
            _DbContext = DbContext;
            _DbSet = DbContext.Set<TEntity>();
        }

        /// <summary>
        /// Get all items from table
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll()
        {
            return _DbSet;
        }

        /// <summary>
        /// Get item by item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetById(int id)
        {
            return _DbSet.Find(id);
        }

        public bool Delete(TEntity obj)
        {
            try
            {
                _DbSet.Remove(obj);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Insert(TEntity obj)
        {
            try
            {

                _DbSet.Add(obj);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Edit(TEntity obj)
        {
            try
            {

                _DbContext.Entry(obj).State = EntityState.Modified;
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return _DbSet.Where(predicate);
        }

        public void Dispose()
        {
        }
    }
}
