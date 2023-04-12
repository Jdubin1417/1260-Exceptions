using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClass_Exceptions
{
    //don't worry about this right now; we'll talk more about it later
    //you won't be tested on this, at least until we talk about inheritance
    public class AgeException : Exception
    {
        public AgeException() : base() { }
        public AgeException(string message) : base(message) { }
        public AgeException(string message, Exception e) : base(message, e) { }
    }
}
