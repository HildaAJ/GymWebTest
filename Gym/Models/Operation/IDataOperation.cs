using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models
{
    public interface IDataOperation<T> where T:class,new()
    {
         void Add(T obj);
         IEnumerable<T> Get();
         void Update(T obj);
         void Delete(T obj);
       
    }
}
