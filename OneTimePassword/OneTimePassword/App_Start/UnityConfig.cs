using Microsoft.Practices.Unity;
using OneTimePassword.Audit;
using OneTimePassword.Business;
using OneTimePassword.Business.Dependencies;
using OneTimePassword.Repository;
using System.Web.Http;
using Unity.WebApi;

namespace OneTimePassword
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserAudit, UserAuditManager>();

            container.RegisterInstance(new UserBusiness(
                container.Resolve<IUserService>(), 
                container.Resolve<IUserAudit>()));
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}