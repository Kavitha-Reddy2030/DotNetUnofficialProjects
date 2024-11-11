using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPIJWT.Middleware
{
    public class GlobalExceptionHandler : Exception
    {
    }

    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException() : base("Employee not found.") { }

        public EmployeeNotFoundException(Guid id)
            : base($"Employee with ID '{id}' was not found.") { }
    }
    public class EmployeeAlreadyExistsException : Exception
    {
        public EmployeeAlreadyExistsException(string email)
            : base($"Employee with Email '{email}' already exists.") { }
    }
}
