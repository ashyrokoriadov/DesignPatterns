using System;

namespace Observer.Models
{
    public class Message
    {
        public Message(string from, string to, string text)
        {
            From = from;
            To = to;
            Text = text;
        }

        public string From { get; init; }
        public string To { get; init; }
        public string Text { get; init; }
        public MessageStatus Status { get; set; }

        public override string ToString() => $"[{nameof(From)}: {From}, " +
            $"{nameof(To)}: {To}, {nameof(Status)}: {Status}]";
    }
}
