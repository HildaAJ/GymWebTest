using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using Gym.Models.ViewModels;

namespace Gym.Models
{
    public class MemberDataOperation : IDataOperation<Member>
    {
        GymDBModel db = new GymDBModel();

        public void Add(Member obj)
        {
            db.Member.Add(obj);
            db.SaveChanges();

        }

        public void Delete(Member obj)
        {
            db.Member.Remove(obj);
            db.SaveChanges();
        }

        public IEnumerable<Member> Get()
        {
            var Members = from c in db.Member select c;
            var allMembers = Members.ToList();
            return allMembers;
        }

        public void Update(Member obj)
        {
            
        }

        public int CheckAddMember(RegisterGroupViewModel member)
        {
            int flg = 0;
           
                var allMember = Get();
                //電話,Email相同 視為同一個會員
                var check = allMember.Where(s => s.Tel == member.Register.Tel ||
                                                     s.Email == member.Register.Email).ToList();
                //會員資料重複
                if (check.Count() >= 1)
                {
                    flg = -1;
                }
                //新增會員
                else
                {
                    Member addMember = new Member
                    {
                        Email = member.Register.Email,
                        Birthday=member.Register.Birthday,
                        Tel=member.Register.Tel,
                        Password=member.Register.Password,
                        Sex=member.Register.Sex,
                        PassWay=member.Register.PassWay,
                        Role_No=member.Register.RoleNo,
                        CreateTime=member.Register.CreateTime,
                        LastLoginTime=member.Register.LastLoginTime,
                        IsLogin=member.Register.IsLogin,
                        Status=member.Register.Status
                    };

                    db.Member.Add(addMember);
                    bool saveFailed;

                    do
                    {
                        saveFailed = false;
                        try
                        {   
                            db.SaveChanges();
                            flg = 0;
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            saveFailed = true;
                            ex.Entries.Single().Reload();
                        }
                    } while (saveFailed);   
                }
            return flg;
        }
        
           
        }
    }


