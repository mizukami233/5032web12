using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace _5032web12.Models
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=File")
        {
        }

        public virtual DbSet<Files> Files { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
