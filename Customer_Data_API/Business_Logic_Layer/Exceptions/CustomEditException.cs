using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Exceptions
{
    public class CustomEditException : Exception
    {
        public CustomEditException() { }

        public CustomEditException(string message) : base(message) { }

        public CustomEditException(string message, Exception innerException) : base(message, innerException) { }
    }
}
