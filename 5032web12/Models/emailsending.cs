namespace _5032web12.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("emailsending")]
    public partial class emailsending
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(150)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(300)]
        public string Subject { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(300)]
        public string Body { get; set; }
    }
}
