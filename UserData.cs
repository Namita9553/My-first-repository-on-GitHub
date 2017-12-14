using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA1
{
    public class UserData
    {
        public string User_id { get; set; }
        public string User_name { get; set; }
        public long User_number { get; set; }
        public List<FlatData> Flats { get; set; }
    }
}