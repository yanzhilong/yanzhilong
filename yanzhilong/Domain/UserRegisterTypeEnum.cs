using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    public enum UserRegisterTypeEnum
    {
        /// <summary>
        /// 用户名注册
        /// </summary>
        UserName = 1,

        /// <summary>
        /// 邮箱注册
        /// </summary>
        Email = 2,

        /// <summary>
        /// 手机注册
        /// </summary>
        PhoneNumber = 3,
    }
}