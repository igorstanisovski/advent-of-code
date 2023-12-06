using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.AdventOfCode2023
{
    public class Node
    {
        public long End { get; set; }
        public long Start { get; set; }
        public long Difference { get; set; }
        public Node(long end, long start, long difference) {
            End = end;
            Start = start;
            Difference = difference;
        }
    }
}
