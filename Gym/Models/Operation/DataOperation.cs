using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{
    public abstract class DataOperation<T,U>
        where T : class
        where U : class
    {
        public abstract void Add(U item);
        public abstract IEnumerable<T> Get();       
        public abstract void Update(U item);
        public abstract void Delete(U item);

    }
}