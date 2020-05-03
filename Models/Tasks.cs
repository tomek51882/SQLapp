namespace SQLapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tasks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tasks()
        {
            Results = new HashSet<Results>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatorId { get; set; }

        public int SubcategoryId { get; set; }

        public int AnswerModelId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public virtual AnswerModelNames AnswerModelNames { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Results> Results { get; set; }
    }
}
