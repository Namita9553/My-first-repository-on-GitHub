using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA1
{
    public class FlatData
    {
        public int Flat_no { get; set; }
        public int Floor { get; set; }
        public string User_id { get; set; }
        public int Resident_count { get; set; }
        public string Date_of_own { get; set; }
        public string Flat_type { get; set; }
        public string Parking_space { get; set; }

        public static implicit operator FlatData(List<FlatData> v)
        {
            throw new NotImplementedException();
        }
    }
}