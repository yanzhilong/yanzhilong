using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Models;

namespace yanzhilong.Infrastructure.Mapper
{
    /// <summary>
    /// 扩展类，用于转换
    /// </summary>
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        //开始写扩展方法
        #region Article

        public static ArticleModel ToModel(this Article entity)
        {
            return entity.MapTo<Article, ArticleModel>();
        }

        public static Article ToEntity(this ArticleModel model)
        {
            return model.MapTo<ArticleModel, Article>();
        }

        public static Article ToEntity(this ArticleModel model, Article destination)
        {
            return model.MapTo(destination);
        }

        #endregion
    }
}