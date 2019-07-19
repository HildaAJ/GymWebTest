using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models
{
    public class MemberDataOperation : IDataOperation<Member>
    {
        GymDBEntities GymDB = new GymDBEntities();

        public void Add(Member obj)
        {
            
        }

        public void Delete(Member obj)
        {
            
        }

        public IEnumerable<Member> Get()
        {
            var Members = from c in GymDB.Member select c;
            var allMembers = Members.ToList();
            return allMembers;
        }

        public void Update(Member obj)
        {
            
        }
    }
}