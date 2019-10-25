using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gym.Models.ViewModels.Admin;

namespace Gym.Models.Operation
{
    public class ClassroomOperation : IDataOperation<Classroom, ClassroomViewModel>
    {
        public void Add(ClassroomViewModel item)
        {
           
        }
 
        /// <summary>
        /// 無差別取得所有教室資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Classroom> Get()
        {
            using (GymEntity db = new GymEntity())
            {
                var allClassroom = from x in db.Classroom select x;
                var ClassroomList = allClassroom.ToList();
                return ClassroomList;
            }
        }

        /// <summary>
        /// 根據指定館別取得教室資料
        /// </summary>
        /// <param name="store">館別</param>
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
        /// <param name="StoreLst">所有館別</param>
        /// <returns></returns>
        public List<List<Classroom>> Get(IEnumerable<Store> StoreLst)
        {
            using (GymEntity db = new GymEntity())
            {
                List<Classroom> tmpClassroom = new List<Classroom>();
                List<List<Classroom>> LstClassroom = new List<List<Classroom>>();
                foreach (Store item in StoreLst)
                {
                    //找出同館別的所有教室
                   var tmpRoom = from x in db.Classroom
                                   where x.Store_No.Equals(item.StoreNo)
                                   select x;
                    tmpClassroom = tmpRoom.ToList();
                    LstClassroom.Add(tmpClassroom);
                }

                return LstClassroom;
            }
        }

        /// <summary>
        /// 根據教室編號回傳教室資料
        /// </summary>
        /// <param name="classroomNo"></param>
        /// <returns></returns>
        public Classroom Get(string classroomNo)
        {
            using (GymEntity db = new GymEntity())
            {
                var data = db.Classroom.Find(classroomNo);
                return data;
            }
        }

        public void Update(ClassroomViewModel item)
        {
            
        }
    }
}