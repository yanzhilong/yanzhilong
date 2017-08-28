﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Infrastructure.Mapper;
using yanzhilong.Domain;
using yanzhilong.Models;

namespace yanzhilong.Infrastructure.Mapper
{
    public class AutoMapperConfiguration
    {
        private static MapperConfiguration _mapperConfiguration;
        private static IMapper _mapper;

        //映射配置文件
        static Action<IMapperConfigurationExpression> action = cfg =>
        {
            cfg.CreateMap<Article, ArticleModel>()
            .ForMember(dest => dest.CategoryID, mo => mo.MapFrom(src => src.category.Id))
            .ForMember(dest => dest.CategoryName, mo => mo.MapFrom(src => src.category.Name))
            .ForMember(dest => dest.UserID, mo => mo.MapFrom(src => src.user.Id))
            .ForMember(dest => dest.DisplayName, mo => mo.MapFrom(src => src.user.DisplayName))
            .ForMember(dest => dest.CategorySelectItems, mo => mo.Ignore());
            
            cfg.CreateMap<ArticleModel, Article>()
            .ForMember(dest => dest.category, mo => mo.MapFrom(src => new Category { Id = src.CategoryID }))
            .ForMember(dest => dest.user, mo => mo.MapFrom(src => new User { Id = src.UserID }));

            cfg.CreateMap<Category, CategoryModel>();
            cfg.CreateMap<CategoryModel, Category>();

            //SxSsize
            cfg.CreateMap<SxSsize, SxSsizeModel>();

            cfg.CreateMap<SxSsizeModel, SxSsize>();

            //SxShoe
            cfg.CreateMap<SxShoe, SxShoeModel>();

            cfg.CreateMap<SxShoeModel, SxShoe>();

            //SxProperty
            cfg.CreateMap<SxProperty, SxPropertyModel>();

            cfg.CreateMap<SxPropertyModel, SxProperty>();

            //SxMainImage
            cfg.CreateMap<SxMainImage, SxMainImageModel>();

            cfg.CreateMap<SxMainImageModel, SxMainImage>();

            //SxImage
            cfg.CreateMap<SxImage, SxImageModel>();

            cfg.CreateMap<SxImageModel, SxImage>();

            //SxColor
            cfg.CreateMap<SxColor, SxColorModel>();

            cfg.CreateMap<SxColorModel, SxColor>();

            //TbItem
            cfg.CreateMap<TbItem, TbItemModel>();

            cfg.CreateMap<TbItemModel, TbItem>();

            //TbProperty
            cfg.CreateMap<TbProperty, TbPropertyModel>();


            cfg.CreateMap<TbPropertyModel, TbProperty>();

            //TbPropertyCategory
            cfg.CreateMap<TbPropertyCategory, TbPropertyCategoryModel>();

            cfg.CreateMap<TbPropertyCategoryModel, TbPropertyCategory>();

            //TbPropertyMapping
            cfg.CreateMap<TbPropertyMapping, TbPropertyMappingModel>();

            cfg.CreateMap<TbPropertyMappingModel, TbPropertyMapping>();

            //User
            cfg.CreateMap<User, UserModel>();

            cfg.CreateMap<UserModel, User>();

            //UploadFile
            cfg.CreateMap<UploadFile, UploadFileModel>();

            cfg.CreateMap<UploadFileModel, UploadFile>();

            //Role
            cfg.CreateMap<Role, RoleModel>();

            cfg.CreateMap<RoleModel, Role>();

            //Role
            cfg.CreateMap<PermissionRecord, PermissionRecordModel>();

            cfg.CreateMap<PermissionRecordModel, PermissionRecord>();

            //JdAuto
            cfg.CreateMap<JdAuto, JdAutoModel>();

            cfg.CreateMap<JdAutoModel, JdAuto>();

            //JdAuto
            cfg.CreateMap<JdAutoPropertyValue, JdAutoPropertyValueModel>();

            cfg.CreateMap<JdAutoPropertyValueModel, JdAutoPropertyValue>();

            //JdItem
            cfg.CreateMap<JdItem, JdItemModel>();

            cfg.CreateMap<JdItemModel, JdItem>();

            //ItemTitle
            cfg.CreateMap<ItemTitle, ItemTitleModel>();

            cfg.CreateMap<ItemTitleModel, ItemTitle>();

        };

        public static void Init()
        {
            //初始化配置文件,生成IMapper对象用于执行转换
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                action(cfg);
            });
            _mapper = _mapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// 单例
        /// </summary>
        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }
    }
}