using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamResourceTool.Dtos;
using TeamResourceTool.Models;

namespace TeamResourceTool.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Project, ProjectDTO>().ReverseMap();
                config.CreateMap<ProjectDTO, Project>().ReverseMap();

                config.CreateMap<Resource, ResourceDTO>().ReverseMap();
                config.CreateMap<ResourceDTO, Resource>().ReverseMap();
            });
        }
    }
}