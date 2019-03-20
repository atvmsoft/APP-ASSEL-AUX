using Application.IO.Site.Controllers;

namespace Microsoft.AspNetCore.Mvc
{
    public static class UrlHelperExtensions
    {
        //public static string GetLocalUrl(this IUrlHelper urlHelper, string localUrl)
        //{
        //    if (!urlHelper.IsLocalUrl(localUrl))
        //    {
        //        return urlHelper.Page("/Account/Login");
        //    }

        //    return localUrl;
        //}

        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            string ret = urlHelper.Action(
                action: nameof(AccountController.ConfirmEmail),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);

#if RELEASE
            ret = ret.Replace("54.233.75.98", "assel.cuptech.com.br");
#endif
            return ret;
        }

        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            string ret = urlHelper.Action(
                action: nameof(AccountController.ResetPassword),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);

#if RELEASE
            ret = ret.Replace("54.233.75.98", "assel.cuptech.com.br");
#endif
            return ret;
        }
    }
}
