using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_API
{
    class City
    {
        public string name{get;set;}
    }
    class MainJSON
    {
        public List<W_List> list { get; set; }
        public City city { get; set; }
    }
}
