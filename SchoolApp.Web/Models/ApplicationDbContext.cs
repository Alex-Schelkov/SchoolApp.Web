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
        [Display(Name = "Номер")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
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
        [Display(Name = "Номер")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Описание проблемы")]
        public string Text { get; set; }
        [Required]
        [Display(Name = "Кабинет")]
        public string Cabinet { get; set; }
        [Required]
        [Display(Name = "ФИО сотрудника")]
        public string Fio { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Display(Name = "Дата принятия в работу")]
        public DateTime? WorkDate { get; set; }
        [Display(Name = "Статус")]
        public int? StateId { get; set; } = 1;
        public State State { get; set; }

    }
}
