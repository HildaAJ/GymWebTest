using Gym.Models.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{ 
    public class StoreOperation :IDataOperation<Store, StoreViewModel>
    {
       /// <summary>
       /// 新增館別資料
       /// </summary>
       /// <param name="obj"></param>
       /// <returns></returns>
        public string Add(StoreViewModel obj)
        {
            using (GymEntity db = new GymEntity())
            {
                string msg = "";

                var cnt = db.Store.Where(c=>c.StoreNo.Equals(obj.StoreNo) || c.Name.Equals(obj.Name)).Select(c=>c);
                if (cnt.Count() > 0)
                {
                    msg = "新增的館別資料已存在!";
                    return msg;
                }
                else
                {
                    Store store = new Store()
                    {
                        StoreNo=obj.StoreNo,
                        Name=obj.Name,
                        Tel=obj.Tel,
                        ServiceInfo=obj.ServiceInfo,
                        ParkingInfo=obj.ParkingInfo,
                        MemberInCnt=0,
                        AccessLimit=Convert.ToInt32(obj.AccessLimit),
                        Address=obj.Address
                    };

                    db.Store.Add(store);

                    bool saveFailed;
                    do
                    {
                        saveFailed = false;
                        try
                        {
                            db.SaveChanges();

                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            
                            ex.Entries.Single().Reload();
                        }
                        catch (DbEntityValidationException ex)
                        {

                        }
                        catch (Exception ex)
                        {
                            
                        }
                    } while (saveFailed);

                    msg = "新增成功";
                    return msg;
                }

            }
                
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
        /// <param name="storeNo">場館id</param>
        /// <returns></returns>
        public string GetName(string storeNo)
        {
            using (GymEntity db = new GymEntity())
            {
                var name = db.Store.Where(a => a.StoreNo.Equals(storeNo)).Select(a => a.Name).ToList();
                return name[0];
            }
        }

        /// <summary>
        /// 根據場館id找到該館資料
        /// </summary>
        /// <param name="storeNo">場館id</param>
        /// <returns></returns>
        public Store GetInfo(string storeNo)
        {
            using (GymEntity db = new GymEntity())
            {
                var store = db.Store.Find(storeNo);
                return store;
            }

        }

        public void Update(StoreViewModel obj)
        {
            using (GymEntity db = new GymEntity())
            {
                var store = db.Store.Find(obj.StoreNo);

                store.Name = obj.Name;
                store.Address = obj.Address;
                store.Tel = obj.Tel;
                store.ServiceInfo = obj.ServiceInfo;
                store.ParkingInfo = obj.ParkingInfo;
                store.AccessLimit =Convert.ToInt32(obj.AccessLimit);


                bool saveFailed;
                do
                {
                    saveFailed = false;
                    try
                    {
                        db.SaveChanges();

                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;
                        ex.Entries.Single().Reload();
                    }
                    catch (Exception)
                    {
                        saveFailed = true;
                    }
                } while (saveFailed);
            }
        }
    }
}