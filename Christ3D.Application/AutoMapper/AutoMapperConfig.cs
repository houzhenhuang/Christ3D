using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Application.AutoMapper
{
    /// <summary>
    /// 静态全局 AutoMapper 配置文件
    /// </summary>
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
           
            Mapper.Initialize(cfg =>
            {
                //这个是领域模型 -> 视图模型的映射，是 读命令
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                //这里是视图模型 -> 领域模式的映射，是 写 命令
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
