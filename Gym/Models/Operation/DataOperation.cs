using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{
    public abstract class DataOperation<T> 
    {
        public abstract void Add(T item);
        public abstract IEnumerable<T> Get();       
        public abstract void Update(T item);
        public abstract void Delete(T item);

    }
}