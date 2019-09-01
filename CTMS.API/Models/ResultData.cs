using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTMS.API.Models
{
    public class ResultData<T>
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public T Result { get; set; }
    }
}
