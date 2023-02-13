using System.Collections.Generic;
using System.IO;

namespace TextEditor
{
    public class Buffer
    {
        string Filename;
        List<Line> LineList;
        List<Position> PositionList;

        public Buffer(string filename = "")
        {
            Filename = filename;
            LineList = new List<Line>();
            PositionList = new List<Position>();

            LineList.Add(new Line());
            PositionList.Add(new Position());
        }

        public Line GetLineAt(int index)
        {
            if ((index > 0) && (index < LineList.Count()))
            {
                return LineList[index];
            }
            else
            {
                return LineList.Last();
            }
        }

        // public Line[] GetLines(int start = 0, int end = 1)
        // {
        //     Line[] lines = {new Line()};

        //     end = Math.Min(end, LineList.Count());
        //     start = Math.Max(start, 0);

        //     start = Math.Min(start, end);

        //     for (int i = start; i < end; i++)
        //     {
        //         lines[i] = GetLineAt(i);
        //     }

        //     return lines;
        // }

        public Position GetActivePosition()
        {
            return PositionList.First();
        }

        public int GetLineCount()
        {
            return LineList.Count();
        }

        public Line AddLine(string text)
        {
            Line l = new Line(text);
            LineList.Add(l);
            return l;
        }
    }
}