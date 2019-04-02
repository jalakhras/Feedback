namespace Feedback.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int AdminId { get; set; }

        //Navigation Property
        public Admin Admin { get; set; }
    }
}