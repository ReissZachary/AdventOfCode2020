using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Helpers
{
    public class Passport
    {
        public bool ByrIncluded { get; set; }
        public bool IyrIncluded { get; set; }
        public bool EyrIncluded { get; set; }
        public bool HgtIncluded { get; set; }
        public bool HclIncluded { get; set; }
        public bool EclIncluded { get; set; }
        public bool PidIncluded { get; set; }

        public bool IsValidPassport()
        {
            return ByrIncluded && IyrIncluded && EyrIncluded && HclIncluded && HgtIncluded && EclIncluded && PidIncluded;
        }
    }
}
