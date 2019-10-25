using Gym.Models.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{ 
    public class StoreOperation :IDataOperation<Store, StoreViewModel>
    {
       
        public void Add(StoreViewModel obj)
        {
           
        }

        public void Delete(StoreViewModel obj)
        {
            
        }
        /// <summary>
        /// 取得所有場館資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Store> Get()
        {
            using (GymEntity db =new GymEntity())
            {
                var allStore = from x in db.Store select x;
                var StoreList = allStore.ToList();
                return StoreList;
            }
           
        }

        /// <summary>
        /// 根據場館id找到名稱
        /// </summary>
        /// <param name="storeNo"></param>
        /// <returns></returns>
        public string GetName(string storeNo)
        {
            using (GymEntity db = new GymEntity())
            {
                var name = db.Store.Where(a => a.StoreNo.Equals(storeNo)).Select(a => a.Name).ToList();
                return name[0];
            }
        }

        public void Update(StoreViewModel obj)
        {
           
        }
    }
}