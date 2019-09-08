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

        public override IEnumerable<Course> Get()
        {
            using (GymEntity db = new GymEntity())
            {
                var AllCourse = from c in db.Course
                                select c;
                var LstCourse = AllCourse.ToList();
                return LstCourse;
            }
        }

        public Course Get(string courseNo)
        {
            using (GymEntity db = new GymEntity())
            {
                var tmpCourse = from c in db.Course
                              where c.CourseNo.Equals(courseNo)
                              select c;
                var course = tmpCourse.ToList();
                return course[0];
            }
        }

        public override void Update(Course item)
        {
            
        }
    }
}