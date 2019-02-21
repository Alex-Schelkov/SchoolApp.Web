using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Web.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

  

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        public DbSet<State> States { get; set; }
        public DbSet<TaskJornal> TaskJornals { get; set; }
    }


    public class State
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<TaskJornal> TaskJornals { get; set; }
        public State()
        {
            TaskJornals = new List<TaskJornal>();
        }
    }

    public class TaskJornal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Cabinet { get; set; }
        [Required]
        public string Fio { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? WorkDate { get; set; }

        public int? StateId { get; set; }
        public State State { get; set; }

    }
}
