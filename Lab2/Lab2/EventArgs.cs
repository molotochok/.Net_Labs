using System;

namespace Lab2
{
    class EventArgs
    {
        public string Text { get; set; }

        public EventArgs(string text)
        {
            Text = text;
        }
    }
}
