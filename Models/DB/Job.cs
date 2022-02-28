using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skilled_Force.Models
{
    public class Job
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string JobId { get; set; }


        [Required]
        [Column("Title")]
        [Display(Name = "Title")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(2000)]
        public string Description { get; set; }

        [Required]
        [Column("CreatedBy")]
        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }

        [Required]
        [Column("UpdatedBy")]
        [Display(Name = "Updated By")]
        public int UpdatedBy { get; set; }

        [Required]
        [Column("CreatedAt")]
        [DisplayFormat(DataFormatString = "{0:d} at {0:t}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("UpdatedAt")]
        [DisplayFormat(DataFormatString = "{0:d} at {0:t}", ApplyFormatInEditMode = true)]
        [Display(Name = "Updated At")]
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
