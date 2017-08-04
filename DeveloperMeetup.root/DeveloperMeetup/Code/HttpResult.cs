using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperMeetup.Code
{
    /// <summary>
    /// Generic API response
    /// </summary>
    public class HttpResult
    {
        public int Status { get; set; }
        public object Data { get; set; }
    }
}
