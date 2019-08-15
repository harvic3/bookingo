using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace BookingoApi.Modules.AppSettings
{
    public static class AppSettings
    {
        /// <summary>
        /// Parameter name of the webConfig file containing the value of the application name in the authentication system
        /// </summary>
        public const string AuthAppNameParameter = "AUTH_APP_NAME";
        /// <summary>
        /// Parameter name of the WebConfig file containing the filename for the authentication system credentials
        /// </summary>
        public const string AuthAppCredentialsFileName = "AUTH_CREDENTIALS_FILE_NAME";

        public static string GetAppSettingsParameter(string keyName)
        {
            return ConfigurationManager.AppSettings[keyName] ?? null;
        }

        public static string GetFullPathOfFileName(string fileName)
        {
            string rootPath = HttpContext.Current.Server.MapPath("~");
            string fullPath = String.Format("{0}{1}", rootPath, fileName);
            return fullPath;
        }
    }
}