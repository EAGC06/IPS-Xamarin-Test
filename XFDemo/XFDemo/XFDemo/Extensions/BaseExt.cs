using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XFDemo.Services;
using System.Threading.Tasks;

namespace XFDemo.Extensions
{
    public static class ResponseObjectExt
    {
        public static async Task ProcessError(this ResponseObject response)
        {
            if (response.StatusCode == 0)
            {
                await App.Current.MainPage.Navigation.NavigationStack.LastOrDefault().DisplayAlert("Application Error", response.StatusMessage, "OK");
            }

            else
            {
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        return;

                    default:
                        await App.Current.MainPage.Navigation.NavigationStack.LastOrDefault().DisplayAlert("Server Error", "Please, try again later.", "OK");
                        break;
                }
            }
        }
    }
}
