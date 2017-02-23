using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFDemo.Model
{
    public class Company
    {
        private string name;
        private string catchPhrase;
        private string bs;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string CatchPhrase
        {
            get
            {
                return catchPhrase;
            }

            set
            {
                catchPhrase = value;
            }
        }

        public string Bs
        {
            get
            {
                return bs;
            }

            set
            {
                bs = value;
            }
        }
    }
}
