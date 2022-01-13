using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        //burası void kısmı
        public bool Success { get; }
        public string Message { get;  }
    }
}
