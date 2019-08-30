using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{
    public class ClassroomOperation : DataOperation<Classroom>, IDataOperation<Classroom>
    {
        public override void Add(Classroom item)
        {
           
        }

        public override void Delete(Classroom item)
        {
            
        }

        /// <summary>
        /// 無差別取得所有教室資料
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Classroom> Get()
        {
            using (GymEntity db = new GymEntity())
            {
                var allClassroom = from x in db.Classroom select x;
                var ClassroomList = allClassroom.ToList();
                return ClassroomList;
            }
        }

        /// <summary>
        /// 根據館別取得教室資料
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public IEnumerable<Classroom> Get(Store store)
        {
            using (GymEntity db = new GymEntity())
            {
                var allClassroom = from x in db.Classroom
                             where x.Store_No.Equals(store.StoreNo)
                             select x;
                var ClassroomList = allClassroom.ToList();
                return ClassroomList;
            }
        }

        /// <summary>
        /// 根據館別 取得所有教室資料
        /// </summary>
        /// <param name="StoreLst"></param>
        /// <returns></returns>
        public List<List<Classroom>> Get(List<Store> StoreLst)
        {
            using (GymEntity db = new GymEntity())
            {
                List<Classroom> tmpClassroom = new List<Classroom>();
                List<List<Classroom>> LstClassroom = new List<List<Classroom>>();
                foreach (Store item in StoreLst)
                {
                   var tmpRoom = from x in db.Classroom
                                   where x.Store_No.Equals(item.StoreNo)
                                   select x;
                    tmpClassroom = tmpRoom.ToList();
                    LstClassroom.Add(tmpClassroom);
                }

                return LstClassroom;
            }
        }

        public override void Update(Classroom item)
        {
            
        }
    }
}