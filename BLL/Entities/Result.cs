using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Result<T> : EmptyResult
    {
        public T Data { get; set; }
    }
}
