namespace TextEditor
{
    public class Line
    {
        public string Content { get; set; } 

        public Line(string text = "")
        {
            Content = text;
        }
    }
}