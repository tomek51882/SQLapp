using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SQLapp.Models
{
    public class Tasks
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string CreatorId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string Content { get; set; }
    }
}