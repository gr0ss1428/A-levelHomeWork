using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Web.Common;
using System.Web.Mvc;
using BlogBl;
using BlogBl.BlModel;
using BlogMvc.Service;

namespace BlogMvc.Tools
{
    public class NinjectDependency : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependency(IKernel kParam)
        {
            kernel = kParam;
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

        public void AddBindings()
        {
            kernel.Bind<IService<ArticleBl>>().To<ArticleService>().WhenInjectedInto<Controllers.ArticleController>();//.WhenInjectedInto<ApiControllers.ArticleController>();
            // kernel.Bind<IService<ArticleBl>>().To<ArticleService>().WhenInjectedInto<ApiControllers.ArticleController>();
            kernel.Bind<IEmailService>().To<EmailService>();
            NinjectDI_Bl.RegisterServices(kernel);
        }
    }
}