﻿using AutoMapper;
using Feedback.Models;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Feedback
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TaskVM, Task>()
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.DueDate, opts => opts.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Completed, opts => opts.MapFrom(src => src.Completed))
                .ForMember(dest => dest.AssociatedMessageId, opts => opts.MapFrom(src => src.AssociatedMessageId))
                .ForMember(dest => dest.AssignedToId, opts => opts.MapFrom(src => src.AssignedToId))
                .ForMember(dest => dest.AssignedTo, opts => opts.MapFrom(src => src.AssignedTo))
                .ForMember(dest => dest.AssociatedMessage, opts => opts.MapFrom(src => src.AssociatedMessage))
                .ForMember(dest => dest.Notes, opts => opts.MapFrom(src => src.Notes));

                cfg.CreateMap<Task, TaskVM>()
                 .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.DueDate, opts => opts.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Completed, opts => opts.MapFrom(src => src.Completed))
                .ForMember(dest => dest.AssociatedMessageId, opts => opts.MapFrom(src => src.AssociatedMessageId))
                .ForMember(dest => dest.AssignedToId, opts => opts.MapFrom(src => src.AssignedToId))
                .ForMember(dest => dest.AssignedTo, opts => opts.MapFrom(src => src.AssignedTo))
                .ForMember(dest => dest.AssociatedMessage, opts => opts.MapFrom(src => src.AssociatedMessage))
                .ForMember(dest => dest.Notes, opts => opts.MapFrom(src => src.Notes));

            });
           
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
