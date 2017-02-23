using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XFDemo.Model;
using XFDemo.Services;

namespace XFDemo.Extensions
{
    public static class UserCredentialsExt
    {
        public async static Task<bool> AuthenticateAsync(this UserCredentials userCred)
        {
            ResponseObject response = await RestHelper<ResponseMessage>.Instance.PostRequestAsync(userCred, "/login");

            if (response.IsSuccessResponse)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
