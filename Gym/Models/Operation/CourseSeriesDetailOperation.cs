using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{
    /// <summary>
    /// 課程方案內容
    /// </summary>
    public class CourseSeriesDetailOperation : DataOperation<CourseSeriesDetail>, IDataOperation<CourseSeriesDetail>
    {
        public override void Add(CourseSeriesDetail item)
        {
            throw new NotImplementedException();
        }

        public override void Delete(CourseSeriesDetail item)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<CourseSeriesDetail> Get()
        {
            throw new NotImplementedException();
        }

        //根據課程方案No取得課程方案內容
        public IEnumerable<CourseSeriesDetail> Get(string SeriesNo)
        {
            using (GymEntity db=new GymEntity())
            {
                var DetailCourse = db.CourseSeriesDetail.Where(a => a.CourseSeries_No == SeriesNo).Select(a => a).ToList();
                return DetailCourse;
            }
        }

        public override void Update(CourseSeriesDetail item)
        {
            throw new NotImplementedException();
        }
    }
}