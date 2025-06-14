using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSerialization
{
    [Serializable] // Required for XML Serialization
    public class Employee
    {
        public string EmployeeName { get; set; }
    }


}
