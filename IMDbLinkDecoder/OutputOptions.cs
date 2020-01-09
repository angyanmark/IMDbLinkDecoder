using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDbLinkDecoder
{
    class OutputOptions
    {
        public bool Counter { get; set; }
        public bool Title { get; set; }
        public bool Date { get; set; }
        public bool TMDb { get; set; }
        public bool Link { get; set; }
        public string Separator { get; set; }
    }
}
