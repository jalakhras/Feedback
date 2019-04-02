using System.Collections.Generic;

namespace Feedback.Models
{
    public class DashBoardVM
    {
        public IEnumerable<MessageThread> Threads { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}