using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    public enum UserLoginResultEnum
    {
        /// <summary>
        /// 登陆成功
        /// </summary>
        Successful = 1,

        /// <summary>
        /// 用户不存在
        /// </summary>
        UserNotExist = 2,

        /// <summary>
        /// 密码错误
        /// </summary>
        WrongPassword = 3,

        /// <summary>
        /// 账户锁定
        /// </summary>
        LockedOut = 4,
    }
}