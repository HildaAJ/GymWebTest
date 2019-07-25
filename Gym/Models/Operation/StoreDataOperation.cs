using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{ 
    public class StoreDataOperation : DataOperation<Store>,IDataOperation<Store>
    {
       
        public override void Add(Store obj)
        {
           
        }

        public override void Delete(Store obj)
        {
            
        }
        /// <summary>
        /// 取得所有場館資料
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Store> Get()
        {
            using (GymEntity db =new GymEntity())
            {
                var allStore = from x in db.Store select x;
                var StoreList = allStore.ToList();
                return StoreList;
            }
           
        }

        public override void Update(Store obj)
        {
           
        }
    }
}