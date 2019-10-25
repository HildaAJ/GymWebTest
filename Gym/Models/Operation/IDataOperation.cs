using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models
{
    public interface IDataOperation<T,U> 
        where T:class
        where U:class
    {
         string Add(U obj);
         IEnumerable<T> Get();
       
    }
}
