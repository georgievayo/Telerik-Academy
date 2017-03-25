using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public interface IPerson
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        string OtherInfo { get; set; }

        DateTime BirthDate { get; }

        bool IsOlderThan(IPerson other);
    }
}
