﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{
    //消費方案
    public class CourseSeriesOperation : DataOperation<CourseSeries>, IDataOperation<CourseSeries>
    {
        public override void Add(CourseSeries item)
        {
            
        }

        public override void Delete(CourseSeries item)
        {
            
        }

        /// <summary>
        /// 取得所有方案資料
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<CourseSeries> Get()
        {
            using (GymEntity db = new GymEntity())
            {
                //回傳未過期及可銷售狀態的方案
                var AllSeries = db.CourseSeries.Where(c=>c.DeadLine>=DateTime.Now && c.SaleEnable==true)
                                               .Select(c => c).ToList();
                return AllSeries;
            }
        }

        /// <summary>
        /// 根據id取得該筆方案資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CourseSeries Get(string id)
        {
            using (GymEntity db = new GymEntity())
            {
                //回傳未過期及可銷售狀態的方案
                var Series = db.CourseSeries.Find(id);
                return Series;
            }
        }

        public override void Update(CourseSeries item)
        {
            
        }
    }
}