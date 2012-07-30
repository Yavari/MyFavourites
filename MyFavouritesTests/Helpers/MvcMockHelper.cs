using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace MyFavouritesTests.Helpers
{
    public static class MvcMockHelper
    {
        public static HttpContextBase GetFakeHttpContext()
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var responseCache = new Mock<HttpCachePolicyBase>();
            var session = new Mock<HttpSessionStateBase>();
            var server = new Mock<HttpServerUtilityBase>();
            var cookie = new HttpCookieCollection();
            var user = new Mock<IPrincipal>();
            var identity = new Mock<IIdentity>();

            request.Setup(req => req.Cookies).Returns(cookie);
            response.Setup(resp => resp.Cookies).Returns(cookie);
            identity.Setup(ident => ident.Name).Returns("kpratt");
            user.Setup(usr => usr.Identity).Returns(identity.Object);

            context.Setup(ctx => ctx.User).Returns(user.Object);
            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Response.Cache).Returns(responseCache.Object);
            context.Setup(ctx => ctx.Session).Returns(session.Object);
            context.Setup(ctx => ctx.Server).Returns(server.Object);

            return context.Object;
        }

        public static void SetFakeControllerContext(this Controller controller)
        {
            var httpContext = GetFakeHttpContext();
            var context = new ControllerContext(new RequestContext(httpContext, new RouteData()), controller);
            controller.ControllerContext = context;
        }
    }
}