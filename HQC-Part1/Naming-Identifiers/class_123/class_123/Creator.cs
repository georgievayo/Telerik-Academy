using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClass
{
    class Creator
    {
        const int MAX_COUNT = 6;
        class Writer
        {
            void ShowVariableAsString(bool variable)
            {
                string varAsString = variable.ToString();
                Console.WriteLine(varAsString);
            }
        }
        public static void EntryMethod()
        {
            Creator.Writer instance = new Creator.Writer();
            instance.ShowVariableAsString(true);
        }
    }
}
