using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gym.Models.ViewModels.Admin;

namespace Gym.Models.Operation
{
    public class CourseOperation : IDataOperation<Course, CourseViewModel>
    {
        public string Add(CourseViewModel item)
        {
            var msg = "";
            return msg;
        }

        public  void Delete(CourseViewModel item)
        {
            
        }

        /// <summary>
        /// 無差別取得所有課程資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Course> Get()
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

        /// <summary>
        /// 預約課程的課程資料
        /// </summary>
        /// <param name="MemberNo">會員編號</param>
        /// <returns></returns>
        public IEnumerable<Course> GetBooking(int MemberNo)
        {
            using (GymEntity db = new GymEntity())
            {
                //會員所有的預約課程
                var allData = db.BookingCourse.Where(a => a.Member_No.Equals(MemberNo)).Select(a => a);

                //找出尚未結束的預約課程 
                var data = from a in allData
                           from b in db.Course
                           where a.Course_No.Equals(b.CourseNo) && b.ClassDate >= DateTime.Now
                           orderby b.ClassDate, b.StartTime
                           select b;
                var lstData = data.ToList();
                return lstData;
            }
        }

        /// <summary>
        /// 過去預約課程的課程資料
        /// </summary>
        /// <param name="MemberNo">會員編號</param>
        /// <returns></returns>
        public IEnumerable<Course> GetPastBooking(int MemberNo)
        {
            using (GymEntity db = new GymEntity())
            {
                //會員所有的預約課程
                var allData = db.BookingCourse.Where(a => a.Member_No.Equals(MemberNo)).Select(a => a);

                var now = DateTime.Now.Ticks;

                //找出近一個月已結束的預約課程
                var pastdata = from a in allData.AsEnumerable()
                               from b in db.Course
                               where a.Course_No.Equals(b.CourseNo) && b.ClassDate < DateTime.Now 
                               let pastDate=b.ClassDate.Ticks
                               let days=new TimeSpan(now- pastDate).Days
                               where days <= 31
                               orderby b.ClassDate, b.StartTime
                               select b;

                //回傳前3筆資料
                int cnt = 0;
                //var lstData = new List<Course>();
                foreach (var item in pastdata)
                {
                    if (cnt < 3)
                    {
                        cnt = cnt + 1;
                        //lstData.Add(item);
                        yield return item;
                    } 
                }

                
            }
        }

        public void Update(CourseViewModel item)
        {
            
        }
    }
}