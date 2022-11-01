using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public override string Message { get; }

        public EntityNotFoundException(string message = "Entity was not found")
        {
            Message = message;
        }
    }
}
