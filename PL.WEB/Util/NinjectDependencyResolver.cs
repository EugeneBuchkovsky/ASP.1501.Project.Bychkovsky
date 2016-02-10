using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfaces;
using BLL.Services;
using BLL.Infrastructure;
using Ninject;
using System.Web.Mvc;

namespace PL.WEB.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        public IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IProfileService>().To<ProfileService>();
            kernel.Bind<IBlogService>().To<BlogService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IArticleService>().To<ArticleService>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<ITagService>().To<TagService>();
        }
    }
}