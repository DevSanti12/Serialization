using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLSerialization
{
    public class Employee
    {
        [XmlAttribute]
        public string EmployeeName { get; set; }
    }


}
