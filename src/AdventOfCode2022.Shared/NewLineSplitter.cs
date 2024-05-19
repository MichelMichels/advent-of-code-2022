using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Shared
{
    public class NewLineSplitter : IStringSplitter
    {
        public string[] Split(string content)
        {
            var separator = "\n";

            if(content.Contains("\r\n"))
            {
                separator = "\r\n";
            }

            return content.Split(separator, StringSplitOptions.None);
        }
    }
}
