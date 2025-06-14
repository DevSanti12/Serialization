using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSerialization
{
    [Serializable] // Required for JSON Serialization
    public class Employee
    {
        public string EmployeeName { get; set; }
    }


}
