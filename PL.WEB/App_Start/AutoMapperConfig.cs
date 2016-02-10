using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.DTO;
using PL.WEB.Models;

namespace PL.WEB.App_Start
{
    public class AutoMapperConfig
    {
        public static void AutoMapper()
        {
            Mapper.CreateMap<UserDTO, UserViewModel>();

            Mapper.CreateMap<BlogDTO, BlogViewModel>();

            Mapper.CreateMap<ArticleDTO, ArticleViewModel>();

            Mapper.CreateMap<ProfileDTO, ProfileViewModel>();

            Mapper.CreateMap<ProfileViewModel, ProfileDTO>();

            Mapper.CreateMap<BlogViewModel, BlogDTO>();

            Mapper.CreateMap<CreateArticleModel, ArticleDTO>();

            Mapper.CreateMap<ArticleViewModel, ArticleDTO>();

            Mapper.CreateMap<TagDTO, TagViewModel>();

            Mapper.CreateMap<CommentDTO, CommentViewModel>();

            Mapper.CreateMap<CommentViewModel, CommentDTO>();
        }
    }
}