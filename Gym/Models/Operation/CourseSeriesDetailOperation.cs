using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gym.Models.ViewModels;
using Gym.Models.ViewModels.Admin;

namespace Gym.Models.Operation
{
    /// <summary>
    /// 課程方案內容
    /// </summary>
    public class CourseSeriesDetailOperation :IDataOperation<CourseSeriesDetail, CourseSeriesDetailViewModel>
    {
        public void Add(CourseSeriesDetailViewModel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(CourseSeriesDetailViewModel item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseSeriesDetail> Get()
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

        public void Update(CourseSeriesDetailViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}