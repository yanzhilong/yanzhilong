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

        #region SxColor

        public static SxColorModel ToModel(this SxColor entity)
        {
            return entity.MapTo<SxColor, SxColorModel>();
        }

        public static SxColor ToEntity(this SxColorModel model)
        {
            return model.MapTo<SxColorModel, SxColor>();
        }

        public static SxColor ToEntity(this SxColorModel model, SxColor destination)
        {
            return model.MapTo(destination);
        }
        #endregion

        #region SxImage

        public static SxImageModel ToModel(this SxImage entity)
        {
            return entity.MapTo<SxImage, SxImageModel>();
        }

        public static SxImage ToEntity(this SxImageModel model)
        {
            return model.MapTo<SxImageModel, SxImage>();
        }

        public static SxImage ToEntity(this SxImageModel model, SxImage destination)
        {
            return model.MapTo(destination);
        }
        #endregion


        #region SxMainImage

        public static SxMainImageModel ToModel(this SxMainImage entity)
        {
            return entity.MapTo<SxMainImage, SxMainImageModel>();
        }

        public static SxMainImage ToEntity(this SxMainImageModel model)
        {
            return model.MapTo<SxMainImageModel, SxMainImage>();
        }

        public static SxMainImage ToEntity(this SxMainImageModel model, SxMainImage destination)
        {
            return model.MapTo(destination);
        }
        #endregion

        #region SxProperty

        public static SxPropertyModel ToModel(this SxProperty entity)
        {
            return entity.MapTo<SxProperty, SxPropertyModel>();
        }

        public static SxProperty ToEntity(this SxPropertyModel model)
        {
            return model.MapTo<SxPropertyModel, SxProperty>();
        }

        public static SxProperty ToEntity(this SxPropertyModel model, SxProperty destination)
        {
            return model.MapTo(destination);
        }
        #endregion

        #region SxShoe

        public static SxShoeModel ToModel(this SxShoe entity)
        {
            return entity.MapTo<SxShoe, SxShoeModel>();
        }

        public static SxShoe ToEntity(this SxShoeModel model)
        {
            return model.MapTo<SxShoeModel, SxShoe>();
        }

        public static SxShoe ToEntity(this SxShoeModel model, SxShoe destination)
        {
            return model.MapTo(destination);
        }
        #endregion


        #region SxSsize

        public static SxSsizeModel ToModel(this SxSsize entity)
        {
            return entity.MapTo<SxSsize, SxSsizeModel>();
        }

        public static SxSsize ToEntity(this SxSsizeModel model)
        {
            return model.MapTo<SxSsizeModel, SxSsize>();
        }

        public static SxSsize ToEntity(this SxSsizeModel model, SxSsize destination)
        {
            return model.MapTo(destination);
        }
        #endregion

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

    }
}