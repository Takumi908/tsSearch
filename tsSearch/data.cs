using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace tsSearch
{
  public  class data
    {     
        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set;}

        public int Isbn { get; set; }

        public Url BookUrl { get; set; }
    }                           
}
