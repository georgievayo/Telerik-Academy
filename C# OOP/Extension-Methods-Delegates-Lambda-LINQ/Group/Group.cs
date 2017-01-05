using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupLib
{
    public class Group
    {
        private int groupNumber;
        private string departmentName;

        public int GroupNumber { get; set; }
        public string DepartmentName { get; set; }

        public Group(int number, string department)
        {
            this.groupNumber = number;
            this.departmentName = department;
        }
    }
}
