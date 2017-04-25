using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Infrastructure.Mapper;
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
            cfg.CreateMap<Article, ArticleModel>();
            cfg.CreateMap<ArticleModel, Article>();
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