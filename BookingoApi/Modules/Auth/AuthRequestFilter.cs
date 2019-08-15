using System;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BookingoApi.Modules.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AuthRequestFilter : ActionFilterAttribute
    {
        public string ModuleName { get; set; }
        public string ModuleAction { get; set; }

        private AuthContract _authContract;
        private AuthContract AuthContract
        {
            get
            {
                _authContract = _authContract ?? new AuthContract();
                return _authContract;
            }
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string authorization = HttpContext.Current.Request.Headers["Authorization"];

            actionContext.Request.Properties.Add("ModuleName", ModuleName);
            actionContext.Request.Properties.Add("ModuleAction", ModuleAction);

            if (string.IsNullOrEmpty(authorization))
            {
                UnAuthorized(actionContext);
            }
            else
            {
                try
                {
                    string token = authorization.Split(' ')[1] ?? null;
                    TokenModel userToken = AuthContract.IsValidToken(token);
                    if (userToken != null)
                    {
                        // TODO: Validate clains
                        actionContext.Request.Properties.Add("AuthorizedRequestId", userToken.Uid);
                        base.OnActionExecuting(actionContext);
                    }
                    else
                    {
                        UnAuthorized(actionContext);
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(string.Format("{0}, Auth: {1}", ex?.InnerException?.Message ?? ex.Message, authorization));
                }
            }
        }

        private static void UnAuthorized(HttpActionContext actionContext)
        {
            actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
        }
    }
}