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
        }
        //public DbSet<Book> Books { get; set; }
    }


    public class State
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Task> Tasks { get; set; }
        public State()
        {
            Tasks = new List<Task>();
        }
    }

    public class Task
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
