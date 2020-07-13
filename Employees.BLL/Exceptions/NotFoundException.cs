using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.BLL.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException (string message): base(message)
        {

        }
    }
}
