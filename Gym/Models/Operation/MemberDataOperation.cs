using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using Gym.Models.ViewModels;
using Gym.Models.Operation;

namespace Gym.Models
{
    public class MemberDataOperation : DataOperation<Member>, IDataOperation<Member>
    {
        public override void Add(Member obj)
        {
            using (GymEntity db = new GymEntity()) {
                db.Member.Add(obj);
                db.SaveChanges();
            }
           
        }

        public override void Delete(Member obj)
        {
            using(GymEntity db = new GymEntity())
            {
                db.Member.Remove(obj);
                db.SaveChanges();
            }
            
        }

        public override IEnumerable<Member> Get()
        {
            using (GymEntity db = new GymEntity())
            {
                var Members = from c in db.Member select c;
                var allMembers = Members.ToList();
                return allMembers;
            }
               
        }

        public override void Update(Member obj)
        {
            
        }

        public int CheckAddMember(RegisterGroupViewModel reg)
        {
            int flg = 0;
           
            var allMember = Get();
                //電話,Email相同 視為同一個會員
            var check = allMember.Where(s => s.Tel == reg.Register.Tel ||
                                                     s.Email == reg.Register.Email).ToList();
            //會員資料重複
            if (check.Count() >= 1)
            {
                flg = -1;
            }
            //新增會員
            else
            {
                using (GymEntity db = new GymEntity())
                {
                    StoreDataOperation store = new StoreDataOperation();
                    var allStore = store.Get();
                    //會員選擇的館別編號
                    var chkStoreNo = from c in reg.StoreCheckList.stores
                                   where c.IsChecked == true
                                   select c.No;
                          
                    if (chkStoreNo.Count() > 0)
                    {   
                        Member addMember = new Member
                        {
                            Email = reg.Register.Email,
                            Birthday = reg.Register.Birthday,
                            Tel = reg.Register.Tel,
                            Password = reg.Register.Password,
                            Sex = reg.Register.Sex,
                            PassWay = reg.Register.PassWay,
                            Role_No = reg.Register.RoleNo,
                            CreateTime = reg.Register.CreateTime,
                            LastLoginTime = reg.Register.LastLoginTime,
                            IsLogin = reg.Register.IsLogin,
                            Status = reg.Register.Status, 
                            Name=reg.Register.Name,
                            
                    };
                        //新增會員可出入館別資料
                        foreach (var No in chkStoreNo)
                        {
                            addMember.Store.Add(db.Store.Where(m => m.StoreNo == No).FirstOrDefault());
                        }

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
                            catch(Exception)
                            {
                                flg = -99;
                            }
                          } while (saveFailed);   
                    }
                    else
                    {
                        //沒有選擇館別
                        flg = -2;
                    }
                    
                }
            }
            return flg;
        }
        
           
        }
    }


