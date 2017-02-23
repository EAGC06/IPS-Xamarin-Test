using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFDemo.Model
{
    public class Address
    {
        private string street;
        private string suite;
        private string city;
        private string zipcode;
        private Geolocation geo;

        public string Street
        {
            get
            {
                return street;
            }

            set
            {
                street = value;
            }
        }

        public string Suite
        {
            get
            {
                return suite;
            }

            set
            {
                suite = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        public string Zipcode
        {
            get
            {
                return zipcode;
            }

            set
            {
                zipcode = value;
            }
        }

        public Geolocation Geo
        {
            get
            {
                return geo;
            }

            set
            {
                geo = value;
            }
        }
    }
}
