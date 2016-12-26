using System;
using System.Text;

namespace ParseTags
{
    class ParseTags
    {
        static void Main()
        {
            string[] text = Console.ReadLine().Split('<', '>');
            string openTag = "upcase";
            string closeTag = "/upcase";
            StringBuilder sb = new StringBuilder();
            bool tagWasOpened = false;
            bool tagWasClosed = true;

            foreach (var part in text)
            {
                if (part == openTag)
                {
                    tagWasClosed = false;
                    tagWasOpened = true;
                }

                if (part == closeTag)
                {
                    tagWasClosed = true;
                    tagWasOpened = false;
                }

                if (part != openTag && part != closeTag && tagWasOpened)
                {
                    sb.Append(part.ToUpper());
                }

                if (part != openTag && part != closeTag && tagWasClosed)
                {
                    sb.Append(part);
                }
            }
            Console.WriteLine(sb.ToString());

        }
    }
}
