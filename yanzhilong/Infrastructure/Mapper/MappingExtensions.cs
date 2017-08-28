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

        #region TbProperty

        public static TbPropertyModel ToModel(this TbProperty entity)
        {
            return entity.MapTo<TbProperty, TbPropertyModel>();
        }

        public static TbProperty ToEntity(this TbPropertyModel model)
        {
            return model.MapTo<TbPropertyModel, TbProperty>();
        }

        public static TbProperty ToEntity(this TbPropertyModel model, TbProperty destination)
        {
            return model.MapTo(destination);
        }
        #endregion

        #region TbPropertyMapping

        public static TbPropertyMappingModel ToModel(this TbPropertyMapping entity)
        {
            return entity.MapTo<TbPropertyMapping, TbPropertyMappingModel>();
        }

        public static TbPropertyMapping ToEntity(this TbPropertyMappingModel model)
        {
            return model.MapTo<TbPropertyMappingModel, TbPropertyMapping>();
        }

        public static TbPropertyMapping ToEntity(this TbPropertyMappingModel model, TbPropertyMapping destination)
        {
            return model.MapTo(destination);
        }
        #endregion

        #region TbPropertyCategory

        public static TbPropertyCategoryModel ToModel(this TbPropertyCategory entity)
        {
            return entity.MapTo<TbPropertyCategory, TbPropertyCategoryModel>();
        }

        public static TbPropertyCategory ToEntity(this TbPropertyCategoryModel model)
        {
            return model.MapTo<TbPropertyCategoryModel, TbPropertyCategory>();
        }

        public static TbPropertyCategory ToEntity(this TbPropertyCategoryModel model, TbPropertyCategory destination)
        {
            return model.MapTo(destination);
        }
        #endregion

        #region TbItem

        public static TbItemModel ToModel(this TbItem entity)
        {
            return entity.MapTo<TbItem, TbItemModel>();
        }

        public static TbItem ToEntity(this TbItemModel model)
        {
            return model.MapTo<TbItemModel, TbItem>();
        }

        public static TbItem ToEntity(this TbItemModel model, TbItem destination)
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

        #region User

        public static UserModel ToModel(this User entity)
        {
            return entity.MapTo<User, UserModel>();
        }

        public static User ToEntity(this UserModel model)
        {
            return model.MapTo<UserModel, User>();
        }

        #endregion

        #region UploadFile

        public static UploadFileModel ToModel(this UploadFile entity)
        {
            return entity.MapTo<UploadFile, UploadFileModel>();
        }

        public static UploadFile ToEntity(this UploadFileModel model)
        {
            return model.MapTo<UploadFileModel, UploadFile>();
        }

        #endregion

        #region Role

        public static RoleModel ToModel(this Role entity)
        {
            return entity.MapTo<Role, RoleModel>();
        }

        public static Role ToEntity(this RoleModel model)
        {
            return model.MapTo<RoleModel, Role>();
        }

        #endregion

        #region PermissionRecord

        public static PermissionRecordModel ToModel(this PermissionRecord entity)
        {
            return entity.MapTo<PermissionRecord, PermissionRecordModel>();
        }

        public static PermissionRecord ToEntity(this PermissionRecordModel model)
        {
            return model.MapTo<PermissionRecordModel, PermissionRecord>();
        }

        #endregion

        #region JdAuto

        public static JdAutoModel ToModel(this JdAuto entity)
        {
            return entity.MapTo<JdAuto, JdAutoModel>();
        }

        public static JdAuto ToEntity(this JdAutoModel model)
        {
            return model.MapTo<JdAutoModel, JdAuto>();
        }

        #endregion

        #region JdAutoPropertyValue

        public static JdAutoPropertyValueModel ToModel(this JdAutoPropertyValue entity)
        {
            return entity.MapTo<JdAutoPropertyValue, JdAutoPropertyValueModel>();
        }

        public static JdAutoPropertyValue ToEntity(this JdAutoPropertyValueModel model)
        {
            return model.MapTo<JdAutoPropertyValueModel, JdAutoPropertyValue>();
        }

        #endregion

        #region JdItem

        public static JdItemModel ToModel(this JdItem entity)
        {
            return entity.MapTo<JdItem, JdItemModel>();
        }

        public static JdItem ToEntity(this JdItemModel model)
        {
            return model.MapTo<JdItemModel, JdItem>();
        }

        #endregion
    }
}