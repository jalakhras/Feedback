using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Feedback.Models
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext() : base("FeedbackConnection")
        {
            Database.SetInitializer(new FeedbackInitializer());
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<MessageThread> Threads { get; set; }

    }

    public class FeedbackInitializer : DropCreateDatabaseIfModelChanges<FeedbackContext>
    {
        protected override void Seed(FeedbackContext context)
        {

        }
    }
}