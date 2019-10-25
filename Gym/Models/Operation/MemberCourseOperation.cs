using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{
    /// <summary>
    /// 會員課程
    /// </summary>
    public class MemberCourseOperation  
    {

        public void Add(List<MemberCourse> LstCourse)
        {
            using (GymEntity db=new GymEntity())
            {
                foreach (MemberCourse course in LstCourse)
                {
                    db.MemberCourse.Add(course);

                    bool saveFailed;
                    do
                    {
                        saveFailed = false;
                        try
                        {
                            db.SaveChanges();

                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            saveFailed = true;
                            ex.Entries.Single().Reload();
                        }
                        catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                        {
                            throw ex;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    } while (saveFailed);
                }
                
            }
        }



        //根據會員編號取得課程資料
        public IEnumerable<MemberCourse> Get(int memberNo)
        {
            using(GymEntity db =new GymEntity())
            {
                var course = db.MemberCourse.Where(a => a.Member_No.Equals(memberNo)).Select(a => a).ToList();
                return course;
            }
        }
        //取得所有會員課程資料
        public IEnumerable<MemberCourse> Get()
        {
            using (GymEntity db = new GymEntity())
            {
                var course = db.MemberCourse.Select(a => a).ToList();
                return course;
            }
        }

        //取得所有會員課程筆數
        public int GetCount()
        {
            using (GymEntity db = new GymEntity())
            {
                var courseCnt = db.MemberCourse.Select(a => a).Count();
                return courseCnt;
            }
        }

        public void Update(MemberCourse item)
        {
            
        }
    }
}