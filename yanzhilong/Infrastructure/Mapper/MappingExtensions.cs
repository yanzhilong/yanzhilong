using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Domain;
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

        #endregion

        #region Category

        public static CategoryModel ToModel(this Category entity)
        {
            return entity.MapTo<Category, CategoryModel>();
        }

        public static Category ToEntity(this CategoryModel model)
        {
            return model.MapTo<CategoryModel, Category>();
        }

        #endregion

        #region Tutorials

        public static TutorialsModel ToModel(this Tutorials entity)
        {
            return entity.MapTo<Tutorials, TutorialsModel>();
        }

        public static Tutorials ToEntity(this TutorialsModel model)
        {
            return model.MapTo<TutorialsModel, Tutorials>();
        }

        #endregion

        #region Product

        public static ProductModel ToModel(this Product entity)
        {
            return entity.MapTo<Product, ProductModel>();
        }

        public static Product ToEntity(this ProductModel model)
        {
            return model.MapTo<ProductModel, Product>();
        }

        #endregion

        #region ResourceStar

        public static ResourceStarModel ToModel(this ResourceStar entity)
        {
            return entity.MapTo<ResourceStar, ResourceStarModel>();
        }

        public static ResourceStar ToEntity(this ResourceStarModel model)
        {
            return model.MapTo<ResourceStarModel, ResourceStar>();
        }

        #endregion


        #region PageViewCount

        public static PageViewCountModel ToModel(this PageViewCount entity)
        {
            return entity.MapTo<PageViewCount, PageViewCountModel>();
        }

        public static PageViewCount ToEntity(this PageViewCountModel model)
        {
            return model.MapTo<PageViewCountModel, PageViewCount>();
        }

        #endregion

        #region Note

        public static NoteModel ToModel(this Note entity)
        {
            return entity.MapTo<Note, NoteModel>();
        }

        public static Note ToEntity(this NoteModel model)
        {
            return model.MapTo<NoteModel, Note>();
        }

        #endregion

    }
}