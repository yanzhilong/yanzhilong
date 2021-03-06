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
            .ForMember(dest => dest.CategoryID, mo => mo.MapFrom(src => src.category.CategoryID))
            .ForMember(dest => dest.CategoryName, mo => mo.MapFrom(src => src.category.Name))
            .ForMember(dest => dest.UserID, mo => mo.MapFrom(src => src.user.UserID))
            .ForMember(dest => dest.DisplayName, mo => mo.MapFrom(src => src.user.DisplayName))
            .ForMember(dest => dest.CategorySelectItems, mo => mo.Ignore());
            
            cfg.CreateMap<ArticleModel, Article>()
            .ForMember(dest => dest.category, mo => mo.MapFrom(src => new Category { CategoryID = src.CategoryID }))
            .ForMember(dest => dest.user, mo => mo.MapFrom(src => new User { UserID = src.UserID }));

            cfg.CreateMap<Tutorials, TutorialsModel>()
           .ForMember(dest => dest.UserID, mo => mo.MapFrom(src => src.user.UserID))
           .ForMember(dest => dest.DisplayName, mo => mo.MapFrom(src => src.user.DisplayName));

            cfg.CreateMap<TutorialsModel, Tutorials>()
            .ForMember(dest => dest.user, mo => mo.MapFrom(src => new User { UserID = src.UserID }));

            cfg.CreateMap<Product, ProductModel>();
            cfg.CreateMap<ProductModel, Product>();

            cfg.CreateMap<Category, CategoryModel>();
            cfg.CreateMap<CategoryModel, Category>();

            cfg.CreateMap<ResourceStar, ResourceStarModel>()
            .ForMember(dest => dest.ResourceTypeSelectItems, mo => mo.Ignore());

            cfg.CreateMap<ResourceStarModel, ResourceStar>();

            cfg.CreateMap<PageViewCount, PageViewCountModel>();

            cfg.CreateMap<PageViewCountModel, PageViewCount>()
            .ForMember(dest => dest.PageViewCountID, mo => mo.Ignore())
            .ForMember(dest => dest.ResourceID, mo => mo.Ignore());

            cfg.CreateMap<NoteModel, Note>();
            cfg.CreateMap<Note, NoteModel>();

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