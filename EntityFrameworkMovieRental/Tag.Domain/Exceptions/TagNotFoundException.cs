using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag.Domain.Exceptions
{

    public class TagNotFoundException : Exception
    {
        public TagNotFoundException(string message): base(message)
        {
            
        }
    }
}
