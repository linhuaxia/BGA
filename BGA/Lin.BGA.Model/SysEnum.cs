using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lin.BGA.Model
{
    public static class SysEnum
    {
        public static Dictionary<int, string> ToDictionary(Type enumType)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            foreach (var item in Enum.GetValues(enumType))
            {
                dic.Add((int)item, Enum.GetName(enumType, (int)item));
            }
            return dic;
        }

        public static string GetName(Type enumType, object value)
        {
            try
            {
                return Enum.GetName(enumType, value);
            }
            catch (Exception)
            {
                return string.Empty;
            }

        }

        public static bool IsParse<T>(string Value)
        {
            try
            {
                var result= (T)Enum.Parse(typeof(T), Value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static T Parse<T>(string Value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), Value);
            }
            catch (Exception)
            {
                return default(T);
            }
        }




        /// <summary>
        /// 用户登录状态
        /// </summary>
        public enum LoginState { 登录成功 = 1, 无权登录, 用户不存在, 密码不正确 }
        public enum ActionHttpMethod { Get = 1, Post }
        public enum ResearchPlanAttachmentType { 课表 = 1, 教案,教案模板 }
        public enum Sex { 男 = 1, 女, 未知 }

        /// <summary>
        /// 系统日志类型，无用
        /// </summary>
        public enum LogType { 系统出错 = 1, 注册验证码, 找回密码验证码 }

        public enum ResearchArea { 区内 = 1, 外区=2 }
        public enum ResearchPlanType { 组织调研 = 1, 个人听课 }
        public enum ResearchPlanStatus { 未开始 = 1, 进行中=21,已结束=31 }
        public enum DepartmentTypeEnum { 区内学校 = 1,区外学校=2,部门=3}
        public enum ResearchScoreLever { 优 = 1, 良 = 2, 合格 = 3, 不合格 = 4 }
        public enum TemplateTypeFlag { 分值模板 = 1, 等级模板 = 2}
        public enum ResearchStatus { 未评 = 1, 待确认=10,已确认=20 }

        public enum LessionGrade {初一=1,初二=2,初三=3,
            高一 = 11, 高二 = 12, 高三 = 13,
            小学一年级 = 31, 小学二年级 = 32, 小学三年级=33, 小学四年级=34, 小学五年级 = 35, 小学六年级 = 36
        }
        /// <summary>
        ///  
        /// </summary>
        public enum PowerActionType { 菜单权限 = 1, 操作权限, 数据级别权限 }


        public enum NewsUserStatus { 未发送 = 1, 未发送成功, 已发送, 已阅 }

        public enum NoticeUserStatus {发布人模板上传=0, 未查看 = 1, 未处理, 已处理 }
        public enum NoticeAttachmentTypeFlag { 文档=1,模板}


        public class Noti
        {
            public enum NotiMissionKeyTypeFlag { 数字 = 1, 文本 = 2 ,日期=3,选择=4}
            public enum NotiMissionDepartmentStatus { 未处理 = 1, 已处理 = 2,处理中=3 }
        }

        public class Work
        {
            public enum WorkKeyTypeFlag { 数字 = 1, 文本 = 2, 日期 = 3,文件=4,选择=5 }
        }

        public class EnableStatus
        {
            public enum EnumEnableStatus { 启用 = 1, 禁用 }
            public static string GetName(bool value)
            {
                if (value)
                {
                    return EnumEnableStatus.启用.ToString();
                }
                return EnumEnableStatus.禁用.ToString();
            }

        }






    }
}