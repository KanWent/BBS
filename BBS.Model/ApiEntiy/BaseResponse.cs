using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Model.ApiEntiy
{
    public class BaseResponse<T>
    {
        public int? code { get; set; }
        public String? msg { get; set; }
        public T data { get; set; }
    }
}
