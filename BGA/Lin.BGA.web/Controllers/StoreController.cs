using Lin.BGA.BLLFactory;
using Lin.BGA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Lin.BGA.Model;
using Tool;
using System.Dynamic;
using System.Text.RegularExpressions;

namespace Lin.BGA.web.Controllers
{
    public class StoreController : BaseMPController
    {

        public ActionResult Index(int page = 1)
        {
            var list = StoreBLL.GetList(p => true);
            list = list.OrderByDescending(p => p.ID);
            var result = list.ToPagedList(page, PageSize);
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        public static bool ValidatePassWord(StoreInfo info)
        {
            //var regex = new Regex(@"
            //                    (?=.*[0-9])                     #必须包含数字
            //                    (?=.*[a-zA-Z])                  #必须包含小写或大写字母
            //                    (?=([\x21-\x7e]+)[^a-zA-Z0-9])  #必须包含特殊符号
            //                    .{6,16}                         #至少8个字符，最多30个字符
            //                    ", RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
            var regex = new Regex(@"
                                (?=.*[0-9])                     #必须包含数字
                                (?=.*[a-zA-Z])                  #必须包含小写或大写字母
                                ", RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
            if (string.IsNullOrEmpty(info.Password))
            {
                return false;
            }
            bool IsPassWordValidate = regex.IsMatch(info.Password);
            return IsPassWordValidate;
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(StoreInfo info)
        {
            info.CreateDate = DateTime.Now;
            info.IP = string.Empty;
            StoreInfo infoExist = StoreBLL.GetList(p => p.Name == info.Name).FirstOrDefault();
            if (null != infoExist)
            {
                return Json(new APIJson(-1,"名称已存在"));
            }
            if (string.IsNullOrEmpty(info.Name))
            {
                return Json(new APIJson(-1,"名称未填写"));
            }
            if (string.IsNullOrEmpty(info.Name.Trim()))
            {
                return Json(new APIJson(-1, "名称不能是空格，请正确填写"));
            }
            if (string.IsNullOrEmpty(info.Code))
            {
                info.Code = info.Name;
            }
            if (!string.IsNullOrEmpty(info.Password))
            {
                bool IsPassWordValidate = ValidatePassWord(info);
                if (!IsPassWordValidate||info.Password.Length<8||info.Password.Length>16)
                {
                    return Json(new APIJson("密码必需包含数字、字母，并且长度在8到16位"));
                }
            }
            else
            {
                info.Password = "hiadilao123456";
            }
            info.Password= Tool.Md5Helper.Md5(info.Password);
            StoreBLL.Create(info);
            if (info.ID > 0)
            {
                return Json(new APIJson(0, "添加成功",new { info.ID,info.Name}));
            }
            return Json(new APIJson(-1, "添加失败"));
        }

        public ActionResult Edit(int id)
        {
            StoreInfo info = StoreBLL.GetList(p => p.ID == id).FirstOrDefault();


            return View(info);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(StoreInfo info)
        {
            StoreInfo infoExist = StoreBLL.GetList(p => p.Name == info.Name&& p.ID!=info.ID).FirstOrDefault();
            if (infoExist != null )
            {
                return Json(new APIJson(-1, "名称已存在"));
            }
            if (string.IsNullOrEmpty(info.Name))
            {
                return Json(new APIJson(-1, "名称未填写"));
            }
            if (string.IsNullOrEmpty(info.Name.Trim()))
            {
                return Json(new APIJson(-1, "名称不能是空格，请正确填写"));
            }
            if (null==info.IP)
            {
                info.IP = string.Empty;
            }
            infoExist = StoreBLL.GetList(p => p.ID == info.ID).FirstOrDefault();
            if (null == infoExist)
            {
                return Json(new APIJson(-1, "parms error"));
            }
            if (!string.IsNullOrEmpty(info.Password))
            {
                bool IsPassWordValidate = ValidatePassWord(info);
                if (!IsPassWordValidate || info.Password.Length < 8 || info.Password.Length > 16)
                {
                    return Json(new APIJson("密码必需包含数字、字母，并且长度在8到16位"));
                }
                infoExist.Password = Tool.Md5Helper.Md5(info.Password);
            }
            
            infoExist.Name = info.Name;
            infoExist.Code = info.Code;
            infoExist.IP = info.IP;
            if (StoreBLL.Edit(infoExist))
            {
                return Json(new APIJson(0, "提交成功"));
            }
            return Json(new APIJson(-1, "提交失败"));
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var info = StoreBLL.GetList(p => p.ID == id).FirstOrDefault();
            if (null == info)
            {
                return Json(new APIJson(-1, "删除失败，参数有误"));
            }
            if (StoreBLL.Delete(info))
            {
                return Json(new APIJson(0, "删除成功"));
            }
            return Json(new APIJson(-1, "删除失败，请重试"));
        }

    }
}
