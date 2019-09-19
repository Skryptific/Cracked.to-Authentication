using System;
using System.Collections.Generic;
using System.Text;

namespace Cracked.to_Authentication
{
    public class Response
    {
        public bool auth { get; set; }
        public string username { get; set; } 
        public string posts { get; set; }
        public string likes { get; set; }
        public string group { get; set; }
    }
}