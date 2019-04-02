using System.Collections.Generic;

namespace Feedback.Models
{
    public class ReplyVM
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public int MessageThreadId { get; set; }
        public virtual List<Message> Messages { get; set; }
    }
}