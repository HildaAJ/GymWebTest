using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gym.Filters;
using Gym.Models.Operation;
using Gym.Models.ViewModels;
using System.Web.Security;
using Gym.Models;
using Gym.Filter;
using System.Globalization;
using System.Net;

namespace Gym.Controllers
{
    public class MemberController : Controller
    {
        RoleAuthManager roleAuth = new RoleAuthManager();

        /// <summary>
        /// 各館資訊
        /// </summary>
        /// <returns></returns>
        //[CommonAuthorize]
        public ActionResult StoreInfo()
        {
            try
            {
                //驗證授權：一般會員及訪客
                //RoleAuthManager roleAuth = new RoleAuthManager();
                var pass = roleAuth.UserGuestAuth();
                if (pass == 0)
                {
                    ViewBag.UserName = roleAuth.UserName();
                }
                else if (pass == 1)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "User";
                }
                else if (pass == 2)
                {
                    ViewBag.RoleName = "Admin";
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.Msg = "無權限瀏覽該網頁，請登入會員或以訪客身分瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                StoreOperation storeOp = new StoreOperation();
                var AllStore = storeOp.Get();//取得所有館別

                List<StoreInfoViewModel> stores = new List<StoreInfoViewModel>();

                foreach (var item in AllStore)
                {
                    StoreInfoViewModel storeVModel = new StoreInfoViewModel();
                    storeVModel.Name = item.Name;
                    storeVModel.Address = item.Address;
                    storeVModel.Tel = item.Tel;
                    storeVModel.Service = item.ServiceInfo;
                    storeVModel.Parking = item.ParkingInfo;
                    storeVModel.MemberInCount = item.MemberInCnt;

                    stores.Add(storeVModel);
                }

                return View(stores);
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.ToString();
                return View();

            }

        }
        /// <summary>
        /// 顯示我的帳戶會員資料
        /// </summary>
        /// <returns></returns>
        public ActionResult Account()
        {
            try
            {
                //驗證授權：一般會員
                //RoleAuthManager roleAuth = new RoleAuthManager();
                var pass = roleAuth.UserAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "User";
                }
                else
                {
                    ViewBag.Msg = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                //取得我的帳戶會員資料
                var Account = GetAccount();

                if (Account != null)
                {
                    List<MemberInfoViewModel> LstAccount = new List<MemberInfoViewModel>();
                    LstAccount.Add(Account);
                    return View(LstAccount);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {

                ViewBag.Msg = ex.ToString();
                return RedirectToAction("Login", "Home");
            }
        }

        /// <summary>
        /// 我的帳戶:修改會員基本資料
        /// </summary>
        /// <returns></returns>
        //[UserAuthorize(Roles = "User")]
        public ActionResult AccountInfo()
        {
            try
            {
                //驗證授權：一般會員
                //RoleAuthManager roleAuth = new RoleAuthManager();
                var pass = roleAuth.UserAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "User";
                }
                else
                {
                    ViewBag.Msg = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }
                //取得我的帳戶會員資料
                var Account = GetAccount();

                if (Account != null)
                {
                    return View(Account);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.ToString();
                return RedirectToAction("Login", "Home");

            }
        }

        /// <summary>
        /// 我的帳戶：修改會員資料
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AccountInfo(MemberInfoViewModel Info)
        {
            try
            {
                //驗證授權：一般會員
                //RoleAuthManager roleAuth = new RoleAuthManager();
                var pass = roleAuth.UserAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "User";
                }
                else
                {
                    ViewBag.Msg = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }
                MemberInfoViewModel afterEdit = new MemberInfoViewModel()
                {
                    Email = Info.Email,
                    Birthday = Info.Birthday,
                    CreateTime = Info.CreateTime,
                    Name = Info.Name,
                    Passway = Info.Passway,
                    Sex = Info.Sex,
                    Status = Info.Status,
                    Tel = Info.Tel
                };

                MemberOperation mo = new MemberOperation();
                mo.Update(afterEdit);

                return RedirectToAction("Account", "Member");
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.ToString();
                return RedirectToAction("Login", "Home");
            }

        }

        //取得我的帳戶會員資料
        private MemberInfoViewModel GetAccount()
        {
            if (User.Identity.IsAuthenticated == true)//若會員為登入狀態
            {
                string Account = User.Identity.Name;//取得會員Email

                //找出該會員資料
                MemberOperation mo = new MemberOperation();
                var member = mo.Get(Account);

                MemberInfoViewModel memInVM = new MemberInfoViewModel();
                string date = member.Birthday.ToString("yyyy-MM-dd").Substring(0, 10);
                memInVM.Email = member.Email;
                memInVM.Birthday = date;
                memInVM.CreateTime = member.CreateTime;
                memInVM.Name = member.Name;
                memInVM.Passway = member.PassWay;
                memInVM.Sex = member.Sex;

                if (member.Status == true)
                {
                    memInVM.Status = "有效會員";
                }
                else { memInVM.Status = "無效會員"; }
                memInVM.Tel = member.Tel;

                return memInVM;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 顯示消費方案
        /// </summary>
        /// <returns></returns>
        public ActionResult CourseSeries()
        {
            try
            {
                //驗證授權：一般會員
                //RoleAuthManager roleAuth = new RoleAuthManager();
                var pass = roleAuth.UserAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "User";
                }
                else
                {
                    ViewBag.Msg = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                //取得消費方案資料
                CourseSeriesOperation cs = new CourseSeriesOperation();
                var allSeries = cs.Get();

                //取得欲顯示消費方案資料 放入ViewModel中
                List<CourseSeriesViewModel> LstSeriesVM = new List<CourseSeriesViewModel>();
                foreach (var item in allSeries)
                {
                    CourseSeriesViewModel SeriesVM = new CourseSeriesViewModel();
                    SeriesVM.Id = item.CourseSeriesNo;
                    SeriesVM.CourseInfo = item.CourseInfo;

                    if (item.DeadLine.Year == 9999)
                    {
                        SeriesVM.DeadLine = "永久";
                    }
                    else
                    {
                        SeriesVM.DeadLine = item.DeadLine.ToShortDateString();
                    }
                    
                    SeriesVM.Description = item.Description;
                    SeriesVM.Name = item.Name;
                    SeriesVM.Price =Convert.ToInt16(item.Price);

                    LstSeriesVM.Add(SeriesVM);
                }

                return View(LstSeriesVM);

            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.ToString();
                return RedirectToAction("Login", "Home");
            }
            
        }

        /// <summary>
        /// 點選的購買方案資訊 
        /// </summary>
        /// <param id="id">方案Id</param>
        /// <returns></returns>
        public ActionResult SeriesDetail(string id)
        {
            try
            {
                //驗證授權：一般會員
               //RoleAuthManager roleAuth = new RoleAuthManager();
                var pass = roleAuth.UserAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "User";
                }
                else
                {
                    ViewBag.Msg = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                CourseSeriesOperation cs = new CourseSeriesOperation();
                var series = cs.Get(id);

                if (series == null)
                {
                    return HttpNotFound();
                }

                var price = Convert.ToInt16(series.Price);
                SeriesDetailViewModel seriesDetail = new SeriesDetailViewModel();
                seriesDetail.SeriesId = series.CourseSeriesNo;
                seriesDetail.Name = series.Name;
                seriesDetail.Price = price;
                seriesDetail.Count = "1";
                seriesDetail.CourseInfo = series.CourseInfo;

                return View(seriesDetail);
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.ToString();
                return RedirectToAction("Login", "Home");
            }
            
        }

        /// <summary>
        /// 點選確認 購買方案
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SeriesDetail(SeriesDetailViewModel model)
        {
            try
            {
                //驗證授權：一般會員 
                var pass = roleAuth.UserAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "User";
                }
                else
                {
                    ViewBag.Msg = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }
                
                var UserEmail = User.Identity.Name;
                MemberOperation member = new MemberOperation();
                //取得會員Id
                var MemberId =member.GetNo(UserEmail);
                //取得會員資料
                var memberData = member.Get(UserEmail);
                //購買方案數量
                var BuyCnt = Convert.ToInt16(model.Count);
                

                //新增方案購買紀錄
                PurchaseRecord purchaseRecord = new PurchaseRecord();
                purchaseRecord.Date = DateTime.Now;  //購買日期
                purchaseRecord.Count = BuyCnt;  //購買數量
                purchaseRecord.PayStatus = true;  //付款狀態
                purchaseRecord.CourseSeries_No = model.SeriesId;  //方案代號
                purchaseRecord.Member_No = MemberId;  //會員id

                PurchaseRecordOperation pr = new PurchaseRecordOperation();
                pr.Add(purchaseRecord);

                //找出課程方案內容
                CourseSeriesDetailOperation csd = new CourseSeriesDetailOperation();
                var seriesDetails=csd.Get(model.SeriesId);
                //找出會員課程table筆數
                MemberCourseOperation mco = new MemberCourseOperation();
                int dataCnt=mco.GetCount();

                //將課程方案內容新增至會員課程
                List<MemberCourse> LstCourses = new List<MemberCourse>();
                foreach (var item in seriesDetails)
                {
                    MemberCourse memberCourse = new MemberCourse();
                    CourseTypeOperation cto = new CourseTypeOperation();
                    memberCourse.MemberCourseNo = dataCnt + 1;
                    memberCourse.CourseType_no = item.CourseType_No;  //課程類型代號
                    memberCourse.Member_No = MemberId;  //會員id
                    memberCourse.Num = item.Num*BuyCnt;  //課程堂數=原方案內容課程數*購買數量

                    LstCourses.Add(memberCourse);
                }
                
                
                mco.Add(LstCourses);

                return RedirectToAction("MyPurchaseSeries", new { MemberId });
            }
            catch (Exception ex)
            {

                ViewBag.Msg = ex.ToString();
                return RedirectToAction("Login", "Home");
            }
            
        }

        /// <summary>
        /// 從首頁直接點進我的購買紀錄
        /// </summary>
        /// <returns></returns>
        public ActionResult Index_MyPurchaseSeries()
        {
            try
            {
                //驗證授權：一般會員 
                var pass = roleAuth.UserAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "User";
                }
                else
                {
                    ViewBag.Msg = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                //取得會員Id 導到MyPurchaseSeries
                var UserEmail = User.Identity.Name;
                MemberOperation member = new MemberOperation();
                var MemberId = member.GetNo(UserEmail);
                return RedirectToAction("MyPurchaseSeries", new { MemberId });

            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.ToString();
                return RedirectToAction("Login", "Home");
            }
            
        }

        /// <summary>
        /// 顯示會員的方案購買紀錄
        /// </summary>
        /// <param name="MemberNo">會員Id</param>
        /// <returns></returns>
        public ActionResult MyPurchaseSeries(int MemberId)
        {
            try
            {
                //驗證授權：一般會員 
                var pass = roleAuth.UserAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "User";
                }
                else
                {
                    ViewBag.Msg = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                //取得會員購買方案資料
                PurchaseRecordOperation pr = new PurchaseRecordOperation();
                var LstRec = pr.Get(MemberId);
                List<MyPurchaseSeriesViewModel> LstVm = new List<MyPurchaseSeriesViewModel>();

                foreach (var item in LstRec)
                {
                    //取得購買方案相關資訊
                    CourseSeriesOperation cs = new CourseSeriesOperation();
                    var csRec = cs.Get(item.CourseSeries_No);
                    var name = csRec.Name;
                    var info = csRec.CourseInfo;
                    var price =Convert.ToInt16(csRec.Price);
                    var payStatus = "";
                    if (item.PayStatus==true)
                    {
                        payStatus = "已付款";
                    }
                    else
                    {
                        payStatus = "未付款";
                    }

                    //顯示會員購買方案
                    MyPurchaseSeriesViewModel vm = new MyPurchaseSeriesViewModel()
                    {
                        Id = item.CourseSeries_No,
                        Name = name,
                        CourseInfo = info,
                        Price = price,
                        Count = item.Count,
                        Date = item.Date.ToString(),
                        PayStatus = payStatus,
                    };

                    LstVm.Add(vm);
                }

                return View(LstVm);

            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.ToString();
                return RedirectToAction("Login", "Home");
            }

        }

        /// <summary>
        /// 顯示我的課程
        /// </summary>
        /// <returns></returns>
        public ActionResult MyCourse()
        {
            //取得會員Id
            var UserEmail = User.Identity.Name;
            MemberOperation member = new MemberOperation();
            var MemberId = member.Get(UserEmail).MemberNo;
            //取得會員課程
            MemberCourseOperation mco = new MemberCourseOperation();
            var LstCourse = mco.Get(MemberId);
            var courses = LstCourse.ToLookup(o => o.CourseType_no, o => o.Num);

            return View();
        }

    }
}