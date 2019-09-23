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

        public CourseType Get(string courseNo)
        {
            using (GymEntity db = new GymEntity())
            {
                var course = db.CourseType.Find(courseNo);
                return course;
            }
        }

        public override void Update(CourseType item)
        {
            
        }
    }
}