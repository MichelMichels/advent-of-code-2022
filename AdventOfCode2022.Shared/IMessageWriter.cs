using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Shared
{
    public interface IMessageWriter
    {
        void WriteBanner();
        void WriteDayBanner(int day);

        void WritePartBanner(int part);
        void WriteAnswer(string answer);
        void WriteMessage(string message);
        void WriteNewLine();
        void WriteError(string message);
    }
}
