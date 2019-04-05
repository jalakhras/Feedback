using System.Collections.Generic;

namespace Feedback.Models
{
    public class DashBoardVM
    {
        public IEnumerable<Message> Messages { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}