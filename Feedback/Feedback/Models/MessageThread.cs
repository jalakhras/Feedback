using System.Collections.Generic;

namespace Feedback.Models
{
    public class MessageThread
    {
        public int MessageThreadId { get; set; }

        //Navigation Property
        public virtual List<Message> Messages { get; set; }
    }
}