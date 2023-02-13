using System.Collections.Generic;

namespace TextEditor
{
    public class Editor
    {
        List<Buffer> Buffers;
        List<Window> Windows;

        public Editor()
        {
            Buffers = new List<Buffer>();
            Windows = new List<Window>();

            Buffers.Add(new Buffer());

            int h = Console.WindowHeight;
            int w = Console.WindowWidth;

            Window InitialWindow = new Window(h, w);
            Windows.Add(InitialWindow);

            // Console.SetBufferSize(w, h); // can't do on Linux (Ubuntu 22.10 + bash)
        }

        public Buffer GetActiveBuffer()
        {
            return Buffers.First();
        }

        public Window GetActiveWindow()
        {
            return Windows.First();
        }

        public void Run()
        { 
            UI ui = new UI(GetActiveWindow());
            ui.Run();
        }
   }
}