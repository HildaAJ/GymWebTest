using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using Gym.Models.ViewModels;
using Gym.Models.Operation;
using System.Security.Cryptography;
using System.Text;


namespace Gym.Models
{
    public class MemberOperation : DataOperation<Member>, IDataOperation<Member>
    {
      
        public Member user { get; private set; }

        public override void Add(Member obj)
        {
            //using (GymEntity db = new GymEntity()) {
            //    db.Member.Add(obj);
            //    db.SaveChanges();
            //}
           
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

        //根據email找出會員資料
        public Member Get(string email)
        {
            using (GymEntity db = new GymEntity())
            {
                var member = db.Member.Where(a => a.Email == email).Select(a => a).ToList();
                return member[0];
            }
        }

        public override void Update(Member obj)
        {
            
        }

        public void Update(MemberInfoViewModel afterEdit)
        {
            using (GymEntity db = new GymEntity())
            {
                var editMember = db.Member.Where(m => m.Email.Equals(afterEdit.Email)).FirstOrDefault();
                editMember.Email = afterEdit.Email;
                if (afterEdit.Status.Equals("有效會員"))
                {
                    editMember.Status = true;
                }
                else
                {
                    editMember.Status = false;
                }
                editMember.Birthday = DateTime.ParseExact(afterEdit.Birthday, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
                editMember.Tel = afterEdit.Tel;
                editMember.Name = afterEdit.Name;
                editMember.Sex = afterEdit.Sex;
                //editMember.PassWay = afterEdit.Passway;
                //editMember.CreateTime = afterEdit.CreateTime;               

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

        /// <summary>
        /// 註冊確認及存取
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public int CheckAddMember(RegisterGroupViewModel reg)
        {
            int flg = 0;
            try
            {
                var allMember = Get();
                //電話,Email相同 視為同一個會員
                var check = allMember.Where(s => s.Tel == reg.Register.Tel ||
                                                         s.Email == reg.Register.Email);
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
                        StoreOperation store = new StoreOperation();
                        //var allStore = store.Get();
                        //會員選擇的館別編號
                        var chkStoreNo = from c in reg.StoreCheckList.stores
                                         where c.IsChecked == true
                                         select c.No;

                        //會員密碼加密
                        var CryptographyPwd = reg.Register.Password.PasswordCryptography();

                        if (chkStoreNo.Count() > 0)
                        {
                            Member addMember = new Member
                            {
                                Email = reg.Register.Email,
                                Birthday = reg.Register.Birthday,
                                Tel = reg.Register.Tel,
                                Password = CryptographyPwd,
                                Sex = reg.Register.Sex,
                                PassWay = reg.Register.PassWay,
                                Role_No = reg.Register.RoleNo,
                                CreateTime = reg.Register.CreateTime,
                                LastLoginTime = reg.Register.LastLoginTime,
                                IsLogin = reg.Register.IsLogin,
                                Status = reg.Register.Status,
                                Name = reg.Register.Name,

                            };
                            //新增會員可出入館別資料
                            foreach (var No in chkStoreNo)
                            {
                                addMember.Store.Add(db.Store.Where(m => m.StoreNo == No).FirstOrDefault());
                            }

                            db.Member.Add(addMember);

                            //處理資料庫儲存
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
                                catch (Exception)
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
            catch (Exception)
            {
                flg = -99;
                return flg;
            }
            
        }

        /// <summary>
        /// 登入確認
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckUserData(LoginViewModel model)
        {
            try
            {
                var allMember = Get();
                var CryptographyPwd =model.Password.PasswordCryptography();
                var tmpUser = allMember.Where(s => s.Email == model.Email && s.Password == CryptographyPwd).ToList();
                if (tmpUser == null)
                {
                    return false;
                }
                else
                {
                    user= tmpUser[0];
                    return true;
                }
                
            }
            catch (Exception)
            {
                return false;
            }
        }

        }

    public static class MemberExtension
    {
        /// <summary>
        /// 密碼加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string PasswordCryptography(this string password)
        {
            SHA256 sha256 = new SHA256CryptoServiceProvider();//建立一個SHA256
            byte[] source = Encoding.Default.GetBytes(password);//將字串轉為Byte[]
            byte[] crypto = sha256.ComputeHash(source);//進行SHA256加密
            string result = Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
            return result;
        }
    }
}


