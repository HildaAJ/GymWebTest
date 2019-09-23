using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{
    /// <summary>
    /// 方案購買紀錄
    /// </summary>
    public class PurchaseRecordOperation : DataOperation<PurchaseRecord>, IDataOperation<PurchaseRecord>
    {
        public override void Add(PurchaseRecord item)
        {
            using (GymEntity db = new GymEntity())
            {
                db.PurchaseRecord.Add(item);
                //處理資料庫儲存
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
                        
                    }
                } while (saveFailed);
            }
        }

        public override void Delete(PurchaseRecord item)
        {
            throw new NotImplementedException();
        }

        //根據會員編號取得方案購買紀錄
        public IEnumerable<PurchaseRecord> Get(int id)
        {
            using (GymEntity db = new GymEntity())
            {
                var rec = db.PurchaseRecord.Where(a => a.Member_No == id).Select(a=>a).ToList();
                return rec;
            }
        }

        public override IEnumerable<PurchaseRecord> Get()
        {
            throw new NotImplementedException();
        }



        public override void Update(PurchaseRecord item)
        {
            throw new NotImplementedException();
        }
    }
}