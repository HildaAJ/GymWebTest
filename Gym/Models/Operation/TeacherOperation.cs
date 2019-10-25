using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using Gym.Models.ViewModels.Admin;

namespace Gym.Models.Operation
{
    public class TeacherOperation : IDataOperation<Teacher,TeacherViewModel>
    {

        public void Add(TeacherViewModel item)
        {
            
        }


        /// <summary>
        /// 取得所有教練資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Teacher> Get()
        {
            using (GymEntity db = new GymEntity())
            {
                var all = db.Teacher.Select(a => a).ToList();
                return all;
            }
        }

        /// <summary>
        /// 根據教練編號回傳資料
        /// </summary>
        /// <param name="id">教練編號</param>
        /// <returns>姓名</returns>
        public Teacher Get(string id)
        {
            using (GymEntity db = new GymEntity())
            {
                var all = db.Teacher.Find(id);
                return all;
            }
        }



        /// <summary>
        /// 根據教練編號回傳姓名
        /// </summary>
        /// <param name="TeacherNo">教練編號</param>
        /// <returns>姓名</returns>
        public string GetName(string TeacherNo)
        {
            using (GymEntity db=new GymEntity())
            {
                var name = db.Teacher.Find(TeacherNo).Name;
                return name;
            }
        }

        /// <summary>
        /// 更新教練資料
        /// </summary>
        /// <param name="item">指定教練資料</param>
        public void Update(TeacherViewModel item)
        {
            using (GymEntity db = new GymEntity())
            {
                var teacher = db.Teacher.Find(item.TeacherNo);
                if (item.Status.Equals("True")) //POST回傳值為字串 要完全一樣的字
                {
                    teacher.Status = true;
                }
                else { teacher.Status = false; }
                teacher.Birthday = DateTime.ParseExact(item.BirDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
                teacher.Name = item.Name;
                teacher.Email = item.EMail;

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
                    catch (Exception)
                    {

                    }
                } while (saveFailed);

            }
        }

       
    }
}