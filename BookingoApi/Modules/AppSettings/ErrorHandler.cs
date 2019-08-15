using BoxAgileDev;
using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace BookingoApi.Modules.AppSettings
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class HandleErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {

            object moduleName = new object(); ;
            context.Request.Properties.TryGetValue("ModuleName", out moduleName);
            object moduleAction = new object();
            context.Request.Properties.TryGetValue("ModuleAction", out moduleAction);
            object userUid = new object();
            context.Request.Properties.TryGetValue("AuthorizedRequestId", out userUid);

            string errorMsg = context.Exception.Message;

            if (context.Exception.InnerException != null)
            {
                errorMsg = context.Exception.InnerException.Message;
            }

            var httpError = new System.Web.Http.HttpError(errorMsg) { { "ErrorCode", 500 } };

            context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
        }

    }
}