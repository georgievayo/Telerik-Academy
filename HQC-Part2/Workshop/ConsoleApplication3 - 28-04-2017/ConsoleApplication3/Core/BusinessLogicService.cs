using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Core;
using SchoolSystem.Models;

namespace SchoolSystem
{
    public class BusinessLogicService
    {
        public void Execute(IReader reader)
        {
            var engine = new Engine(reader);
            engine.Start();
        }
    }
}
