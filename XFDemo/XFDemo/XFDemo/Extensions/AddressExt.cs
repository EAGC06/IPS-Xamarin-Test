using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XFDemo.Model;

namespace XFDemo.Extensions
{
    public static class AddressExt
    {
        public static string GetFullAddress(this Address address)
        {
            return address.Suite
                + " "
                + address.Street
                + ", "
                + address.City;
        }
    }
}
