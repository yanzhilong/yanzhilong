using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    public class UseUpdateResult
    {
        /// <summary>
        /// 错误列表
        /// </summary>
        public IList<string> Errors { get; set; }
        
        public UseUpdateResult()
        {
            this.Errors = new List<string>();
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success
        {
            get { return !this.Errors.Any(); }
        }

        /// <summary>
        /// 添加一个错误
        /// </summary>
        /// <param name="error">Error</param>
        public void AddError(string error)
        {
            this.Errors.Add(error);
        }
    }
}