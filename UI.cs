namespace TextEditor
{
    public class UI
    {
        Window window;

        public UI(Window window)
        {
            this.window = window;
        }

        public void Run()
        {
            Console.Clear();

            bool ReadMore = true;
            while (ReadMore)
            {

                DrawMenu();
                DrawStatus();

                DrawWindow();

                ReadMore = HandleInput();
            }
        }

        public void DrawLine(string text, int Left = 0, int Top = 0, ConsoleColor bg = ConsoleColor.Black, ConsoleColor fg = ConsoleColor.White, bool preserveCursorLocation = true)
        {
            Cursor c = new Cursor();

            if (preserveCursorLocation)
            {
                c = window.GetActiveCursor();
            }

            Console.SetCursorPosition(Left, Top);

            Console.BackgroundColor = bg;
            Console.ForegroundColor = fg;

            string padding = new String(' ', window.Width - text.Length);
            string lineText = text + padding;

            Console.Write(lineText);

            if (preserveCursorLocation)
            {
                Console.SetCursorPosition(c.Position.Left, c.Position.Top);
            }
        }

        public void DrawMenu()
        {
            DrawLine("e v0.02", 0, 0, ConsoleColor.DarkBlue, ConsoleColor.White);
        }

        public void DrawWindow()
        {
            // show buffer text
            Cursor c = window.GetActiveCursor();
            Line l = window.GetLineAt(c.Position.Top);
            DrawLine(l.Content, 0, c.Position.Top, ConsoleColor.Black, ConsoleColor.Gray);
        }

        public void DrawStatus()
        {
            Cursor c = window.GetActiveCursor();
            string status = string.Format("Line: {0}, Column: {1}", c.Position.Top, c.Position.Left);

            DrawLine(status, 0, window.Height, ConsoleColor.DarkBlue, ConsoleColor.White);
        }

        public bool HandleInput()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Q && key.Modifiers == ConsoleModifiers.Control)
            {
                HandleQuit();
                return false;
            }

            Buffer b = window.GetActiveBuffer();
            Cursor c = window.GetActiveCursor();
            Position p = c.Position;
            Line l = b.GetLineAt(p.Top);

            if (key.Key == ConsoleKey.UpArrow && p.Top > 0)
            {
                p.Top--;
            }
            else if (key.Key == ConsoleKey.DownArrow && p.Top < (window.Height - 1))
            {
                p.Top++;
            }
            else if (key.Key == ConsoleKey.LeftArrow && p.Left > 0)
            {
                p.Left--;
            }
            else if (key.Key == ConsoleKey.RightArrow && p.Top < l.Content.Length)
            {
                p.Left++;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                b.AddLine("");
                p.Left = 0;
                p.Top++;
                l = b.GetLineAt(p.Top);
            }
            else if (key.Key == ConsoleKey.Backspace && p.Left > 0)
            {
                p.Left--;
                l.Content = l.Content.Substring(0, p.Left) + l.Content.Substring(p.Left + 1);
            }
            else if (key.Key == ConsoleKey.Delete)
            {
                l.Content = l.Content.Substring(0, p.Left) + l.Content.Substring(p.Left + 1);
            }
            else if (!char.IsControl(key.KeyChar))
            {
                l.Content = l.Content.Substring(0, p.Left) + key.KeyChar + l.Content.Substring(p.Left);
                p.Left++;
            }

            Console.SetCursorPosition(p.Left, p.Top);

            return true;
        }

        private void HandleQuit()
        {
            Console.Clear();
        }
    }
}

