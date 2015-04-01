using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;
using Castle.Windsor;
using IDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;

namespace StartCompeting.Frontend.Web.Plumping
{
    public class WindsorResolver : IDependencyResolver
    {
        private readonly IKernel kernel;
        private IDisposable disposable;

        public WindsorResolver(IKernel kernel)
        {
            this.kernel = kernel;
            disposable = kernel;
        }
 
        public IDependencyScope BeginScope()
        {
            return new WindsorScope(kernel);
        }
 
        public object GetService(Type type)
        {
            return kernel.HasComponent(type) ? kernel.Resolve(type) : null;
        }
 
        public IEnumerable<object> GetServices(Type type)
        {
            return kernel.ResolveAll(type).Cast<object>();
        }
 
        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}