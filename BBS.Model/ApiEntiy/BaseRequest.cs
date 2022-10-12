using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Model.ApiEntiy
{
    public class BaseRequest<T>
    {
        public Header? header { get; set; }

        public T? data { get; set; }
    }

    public class Header 
    {
        public string? token { get; set; }
        public string? Auth { get; set; }
    }
}
