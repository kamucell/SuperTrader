using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperTrader.Core.Entities;


namespace SuperTrader.Core.DataAccess.EFRepository
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
        
    {
        


        protected EfEntityRepositoryBase()
        {
       
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                var qry = context.Set<TEntity>().AsQueryable();
                return await qry.SingleOrDefaultAsync(filter);
            }
        }



        public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null, int takeLineNumber = 0)
        {
            using (var context = new TContext())
            {
                var qry = context.Set<TEntity>().AsQueryable();
                if (filter is not null) qry = qry.Where(filter);
                if (order is not null)  qry = order(qry);
                if(takeLineNumber>0) qry = qry.Take(takeLineNumber);

                return await qry.ToListAsync();
            }
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }


   



        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
    }
}