using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{
    public class CourseTypeOperation : DataOperation<CourseType>, IDataOperation<CourseType>
    {
        public override void Add(CourseType item)
        {
            
        }

        public override void Delete(CourseType item)
        {
            
        }

        public override IEnumerable<CourseType> Get()
        {
            using (GymEntity db = new GymEntity())
            {
                var AllCourse = from c in db.CourseType
                                select c;
                var LstCourse = AllCourse.ToList();
                return LstCourse;
            }
        }

        /// <summary>
        /// 根據課程類型編號取得該資料
        /// </summary>
        /// <param name="courseTypeNo"></param>
        /// <returns></returns>
        public CourseType Get(string courseTypeNo)
        {
            using (GymEntity db = new GymEntity())
            {
                var course = db.CourseType.Find(courseTypeNo);
                return course;
            }
        }

        public override void Update(CourseType item)
        {
            
        }
    }
}