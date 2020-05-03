namespace SQLapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Results
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public int TaskId { get; set; }

        public DateTime? CompletionDate { get; set; }

        public int Score { get; set; }

        public string userAnswerSQL { get; set; }

        public virtual Tasks Tasks { get; set; }
    }
}
