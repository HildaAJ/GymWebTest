using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{
    public class TeacherOperation : DataOperation<Teacher>, IDataOperation<Teacher>
    {
        public override void Add(Teacher item)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Teacher item)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Teacher> Get()
        {
            throw new NotImplementedException();
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

        public override void Update(Teacher item)
        {
            throw new NotImplementedException();
        }
    }
}