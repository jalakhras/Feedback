using Feedback.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Feedback.Models
{
    [Bind(Exclude = "AssignedTo, AssociatedMessage, Category")]
    public class Task 
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DueDate(ErrorMessage = "Date must be in the future")]
        public DateTime? DueDate { get; set; }
        [Required]
        public int AssignedToId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int AssociatedMessageId { get; set; }
        public DateTime? Created { get; set; }
        [StringLength(1000, MinimumLength = 20)]
        public string Notes { get; set; }
        [Required]
        public bool Completed { get; set; }

        //Navigation Properties
        public virtual Admin AssignedTo { get; set; }
        public virtual Message AssociatedMessage { get; set; }
        public virtual Category Category { get; set; }

    }
}