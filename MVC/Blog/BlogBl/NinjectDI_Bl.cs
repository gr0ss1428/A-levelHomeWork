using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using BlogDal.Repository;
using BlogDal.Entity;
using NPoco;

namespace BlogBl
{
   public class NinjectDI_Bl
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IGenericRepository<Article>>().To<GenericRepository<Article>>();
            kernel.Bind<IDatabase>().To<Database>().WithConstructorArgument("connectionStringName", "DBBLOG");
        }
    }
}
