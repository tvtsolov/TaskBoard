using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksBoard.TaskBoard.Exceptions
{
    public class ElementAlreadyExistsException : ApplicationException
    {
        public ElementAlreadyExistsException(string message) 
            : base(message) { }
    }
}
