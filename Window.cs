using System.Collections.Generic;

namespace TextEditor
{
    public class Window
    {
        const int DEFAULT_HEIGHT = 24;
        const int DEFAULT_WIDTH = 80;

        Buffer Buffer;
        List<Cursor> CursorList;
        public int Height { get; }
        public int Width { get; }

        public Window(int height = DEFAULT_HEIGHT, int width = DEFAULT_WIDTH)
        {
            Buffer = new Buffer();
            CursorList = new List<Cursor>();

            Cursor c = new Cursor();
            c.Position.Top = 1;
            CursorList.Add(c);

            Height = height;
            Width = width;
        }

        public Buffer GetActiveBuffer()
        {
            return Buffer;
        }

        public Cursor GetActiveCursor()
        {
            return CursorList.First();
        }

        public Line GetLineAt(int index)
        {
            return Buffer.GetLineAt(index);
        }
    }
}