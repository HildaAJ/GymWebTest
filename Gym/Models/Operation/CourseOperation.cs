using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{
    public class CourseOperation : DataOperation<Course>, IDataOperation<Course>
    {
        public override void Add(Course item)
        {
            
        }

        public override void Delete(Course item)
        {
            
        }

        /// <summary>
        /// 無差別取得所有課程資料
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Course> Get()
        {
            using (GymEntity db = new GymEntity())
            {
                var allCourseItem = from x in db.Course select x;
                var CourseItemList = allCourseItem.ToList();
                return CourseItemList;
            }
        }
        /// <summary>
        /// 根據指定教室取得課程項目
        /// </summary>
        /// <param name="room">教室</param>
        /// <returns></returns>
        public IEnumerable<Course> Get(Classroom room)
        {
            using (GymEntity db = new GymEntity())
            {
                var allCourseItem = from x in db.Course
                                   where x.Classroom_No.Equals(room.ClassroomNo)
                                   select x;
                var CourseItemList = allCourseItem.ToList();
                return CourseItemList;
            }
        }

        /// <summary>
        /// 根據教室 取得所有課程項目
        /// </summary>
        /// <param name="RoomLst">所有教室</param>
        /// <returns></returns>
        public List<List<Course>> Get(List<Classroom> RoomLst)
        {
            using (GymEntity db = new GymEntity())
            {
                List<Course> tmpCourseItem = new List<Course>();
                List<List<Course>> LstCourseItem = new List<List<Course>>();
                foreach (Classroom item in RoomLst)
                {
                    var tmpCourse = from x in db.Course
                                  where x.Classroom_No.Equals(item.ClassroomNo)
                                  select x;
                    tmpCourseItem = tmpCourse.ToList();
                    LstCourseItem.Add(tmpCourseItem);
                }

                return LstCourseItem;
            }
        }


        public override void Update(Course item)
        {
            
        }
    }
}