using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Common.Contracts
{
    public interface IFileLogger
    {
        void Info(string msg);

        void Error(string msg);

        void Fatal(string msg);
    }
}
