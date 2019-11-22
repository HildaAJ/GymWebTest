using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{
    public class RoleOperation /*: DataOperation<Role>, IDataOperation<Role>*/
    {
        public void Add(Role item)
        {
            
        }

        public void Delete(Role item)
        {
            
        }

        public IEnumerable<Role> Get()
        {
            using(GymEntity db =new GymEntity())
            {
                var Role = from c in db.Role select c;
                var allRole = Role.ToList();
                return allRole;
            }
        }

        public void Update(Role item)
        {
            
        }
    }
}