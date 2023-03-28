using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsicPanel.Shared.Entities
{
    public class Result<T> : EmptyResult
    {
        public T Data { get; set; }
    }
}
