using AutoMapper;
using Blog.Entities.Concrete;
using Blog.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.BusinessLogic.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ForMember(x=>x.Note,opt=>opt.MapFrom(y=> "Bu bir nottur."));
        }
    }
}
