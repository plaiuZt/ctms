using AutoMapper;
using CTMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTMS.Web
{
    public class AutoMapperConfigs : Profile
    {
        //添加你的实体映射关系.
        public AutoMapperConfigs()
        {
            CreateMap<SysMenu, SysMenuView>();
            CreateMap<SysMenuView, SysMenu>();
        }
    }
}
