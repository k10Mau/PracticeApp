﻿using MSTest.PersonDetailsApp.Contract;
using MSTest.PersonDetailsApp.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTest.PersonDetailsApp.Services
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private DbContext _dbContext;
        private DbSet<TEntity> _dbSet;
        private ILogHandler log;
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
        public void Delete(TEntity obj)
        {
            try
            {
                _dbSet.Remove(obj);
            }
            catch(Exception ex)
            {
                log.LogError(ex.Message);
            }
        }

        public TEntity FindByID(object id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public void Insert(TEntity obj)
        {
            try
            {
                _dbSet.Add(obj);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                _dbContext.Entry(obj).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }
        }
    }
}
