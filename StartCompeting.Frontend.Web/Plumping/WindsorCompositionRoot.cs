using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace StartCompeting.Frontend.Web.Plumping
{
    public class WindsorCompositionRoot : IHttpControllerActivator
    {
        readonly IWindsorContainer _container;

        public WindsorCompositionRoot(IWindsorContainer container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var scope = _container.BeginScope();
            var controller = (IHttpController)_container.Resolve(controllerType);

            request.RegisterForDispose(new Release(scope.Dispose));

            return controller;
        }

        private class Release : IDisposable
        {
            readonly Action _release;

            public Release(Action release)
            {
                _release = release;
            }

            public void Dispose()
            {
                _release();
            }
        }
    }
}