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

    }
}