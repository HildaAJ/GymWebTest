using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gym.Models.Operation;

namespace Gym.Models.ViewModels
{
    
    /// <summary>
    /// 會員註冊頁面用Model
    /// </summary>
    public class RegisterGroupViewModel
    {
        //館別的複選按鈕
        public StoreCheckListViewModel StoreCheckList { get; set; }
        //其他登入欄位
        public RegisterViewModel Register { get; set; } 
    }

    /// <summary>
    /// 館別的複選按鈕
    /// </summary>
    public class StoreCheckListViewModel
    {
        public List<StoreCheckboxListItem> stores { get; set; } //所有館別
        public string[] StoreValue { get; set; } //選擇館別

        public void listStoreItems()
        {
            List<StoreCheckboxListItem> checkList = new List<StoreCheckboxListItem>();

            //從館別資料表取得目前所有館別資料
            StoreDataOperation store = new StoreDataOperation();
            var allStore = store.Get().ToList();

            //根據館別新增對應的Checkbox
            foreach (Store item in allStore)
            {
                checkList.AddRange(new[]{
                new StoreCheckboxListItem(){DisplayText=item.Name,No=item.StoreNo,IsChecked=false}
            });
            }

            stores = checkList;

        }
    }
}