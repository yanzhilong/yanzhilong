using System.Collections.Generic;
using System.Web.Routing;

namespace yanzhilong.Menu
{
    /// <summary>
    /// 菜单节点类
    /// </summary>
    public class SiteMapNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteMapNode"/> class.
        /// </summary>
        public SiteMapNode()
        {
            RouteValues = new RouteValueDictionary();
            ChildNodes = new List<SiteMapNode>();
        }

        /// <summary>
        /// 系统名称，用于确定菜单激活
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 显示标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Controller名字
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// Action名字
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 路由值
        /// </summary>
        public RouteValueDictionary RouteValues { get; set; }

        /// <summary>
        /// 不设置Action和Controller的时候直接指定Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 子菜单列表
        /// </summary>
        public IList<SiteMapNode> ChildNodes { get; set; }

        /// <summary>
        /// 字体图标的class (Font Awesome: http://fontawesome.io/)
        /// </summary>
        public string IconClass { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// 是否在新窗口打开
        /// </summary>
        public bool OpenUrlInNewTab { get; set; }
    }
}
