using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Security
{
    public class PermissionRecordProvider
    {
        public static readonly string ManageArticle = "ManageArticle";//文章管理
        public static readonly string ManageRole = "ManageRole";//角色管理
        public static readonly string ManagePermissionRecord = "ManagePermissionRecord";//权限管理
        public static readonly string ModifyPassword = "ModifyPassword";//修改密码
        public static readonly string ManageUserInfo = "ManageUserInfo";//用户基本信息管理
        public static readonly string ManageCategory = "ManageCategory";//分类管理
        public static readonly string ManageResource = "ManageResource";//文件管理
        public static readonly string ManageShoe = "ManageShoe";//鞋子管理
        public static readonly string ManageTbProperty = "ManageTbProperty";//淘宝属性管理
        public static readonly string ManageTbPropertyCategory = "ManageTbPropertyCategory";//淘宝属性分类管理
        public static readonly string ManageJdAuto = "ManageJdAuto";//京东自动填写单
        public static readonly string ManageJdItem = "ManageJdItem";//京东宝贝
        public static readonly string ManageTbItem = "ManageTbItem";//淘宝宝贝管理
        public static readonly string ManageUser = "ManageUser";//用户管理

    }
}