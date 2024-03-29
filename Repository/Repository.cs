﻿using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_commerce.Repository
{
    public class Repository <T> : IRepository<T> where T : class
    {

        Context context;
        public Repository(Context context)
        {
            this.context = context;
        }


        public void insert(T entity)
        {
            context.Set<T>().Add(entity);

        }
        public void delete(T entity)
        {
           if(entity is ISoftDeletable item)
            {
                item.IsDeleted = true;
            }
            
         
        }

        public void update(T entity)
        {
            context.Set<T>().Update(entity);
        }
        public ICollection<T> GetAll()
        {
            return context.Set<T>().ToList();
        }


        //find and thing name ,id and etc.....
        public T Get(Func<T, bool> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }

        public int save()
        {
          return  context.SaveChanges();
        }

      
    }
 
}
