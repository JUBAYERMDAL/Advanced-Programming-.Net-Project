using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using travelia.Models;

namespace travelia.Repository.Generic
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        traveliaEntitiesContext context;
        public Repository()
        {
            context = new traveliaEntitiesContext();
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }
    }
}