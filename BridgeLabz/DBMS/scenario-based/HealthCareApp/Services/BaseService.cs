using System;
using System.Collections.Generic;
using HealthCareApp.Models;

namespace HealthCareApp.Services
{
    public class BaseService<T> where T : Entity
    {
        protected List<T> collection = new List<T>();
        protected int nextId = 1;

        public virtual void Add(T entity)
        {
            entity.ID = nextId++;
            collection.Add(entity);
        }

        public virtual void Remove(int id)
        {
            T entity = collection.Find(e => e.ID == id);
            if (entity != null)
                collection.Remove(entity);
            else
                Console.WriteLine("Entity not found");
        }

        public virtual T Get(int id)
        {
            return collection.Find(e => e.ID == id);
        }

        public virtual void DisplayAll()
        {
            foreach (T e in collection)
                e.Display();
        }
    }
}
