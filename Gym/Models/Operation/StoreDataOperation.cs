using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{
    public class StoreDataOperation : IDataOperation<Store>
    {
        GymDBModel db = new GymDBModel();

        public void Add(Store obj)
        {
           
        }

        public void Delete(Store obj)
        {
            
        }

        public IEnumerable<Store> Get()
        {
            var allStore = from x in db.Store select x;
            var StoreList = allStore.ToList();
            return StoreList;
        }

        public void Update(Store obj)
        {
           
        }
    }
}