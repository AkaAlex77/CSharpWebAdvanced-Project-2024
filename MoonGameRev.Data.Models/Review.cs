﻿namespace MoonGameRev.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static MoonGameRev.Common.EntityValidationConstants.Review;

    [Comment("Review for a game")]
    public class Review
    {
        [Key]
        [Comment("Unique identifier for the review.")]
        public int Id { get; set; }

        [Required]
        [Comment("Rating given by the user for the game")]
        public int Rating { get; set; }

        [Required]
        [Comment("Comment provided by the user for the review.")]
        [MaxLength(CommentMaxLength)]
        public string Comment { get; set; } = null!;

        [Required]
        [Comment("Date and time when the review was submitted.")]
        public DateTime ReviewDate { get; set; }


        public int GameID { get; set; }
        [ForeignKey(nameof(GameID))]
        public Game Game { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
    }
}
