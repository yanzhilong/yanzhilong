using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    public class UserLoginResult
    {
        /// <summary>
        /// 登陆状态
        /// </summary>
        public UserLoginResultEnum UserLoginResultEnum { get; set; }

        /// <summary>
        /// 剩余密码验证次数
        /// </summary>
        public int? TryCount { get; set; }
    }
}