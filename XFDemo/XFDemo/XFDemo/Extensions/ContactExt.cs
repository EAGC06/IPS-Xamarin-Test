using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XFDemo.Model;
using XFDemo.Services;

namespace XFDemo.Extensions
{
    public static class ContactExt
    {
        public async static Task LoadContactsAsync(this List<Contact> contacts)
        {
            ResponseObject response = await RestHelper<List<Contact>>.Instance.GetRequestAsync("/contacts");

            if (response.IsSuccessResponse)
            {
                foreach (Contact item in response.Content as List<Contact>)
                {
                    contacts.Add(item);
                }
            }

            else
            {
                await response.ProcessError();
            }
        }
    }
}
