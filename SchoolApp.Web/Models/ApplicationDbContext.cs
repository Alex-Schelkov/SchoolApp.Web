using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.DataAnnotations;

namespace SchoolApp.Web.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
            if (Database.EnsureCreated())
            {
                //Database.ExecuteSqlCommand("ALTER TABLE `helpdeskschool`.`states` COLLATE = utf8;");
              //  Database.ExecuteSqlCommand("ALTER TABLE `helpdeskschool`.`TaskJornals` COLLATE = utf8;");
                Database.ExecuteSqlCommand("INSERT INTO `helpdeskschool`.`States` (`Id`,`Name`) VALUES(1,'Создано');");
                Database.ExecuteSqlCommand("INSERT INTO `helpdeskschool`.`States` (`Id`,`Name`) VALUES(2,'В работе');");
                Database.ExecuteSqlCommand("INSERT INTO `helpdeskschool`.`States` (`Id`,`Name`) VALUES(3,'Исполнено');");
                Database.ExecuteSqlCommand("INSERT INTO `helpdeskschool`.`States` (`Id`,`Name`) VALUES(4,'Архив');");
            }
        }

  

        protected override void OnModelCreating(ModelBuilder builder)
        {
       
            base.OnModelCreating(builder);

        }

        public DbSet<State> States { get; set; }
        public DbSet<TaskJornal> TaskJornals { get; set; }
    }

    [MySqlCharset("utf8")]
    public class State
    {
        [Key]
        [Display(Name = "Номер")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Статус")]
        public string Name { get; set; }
        public List<TaskJornal> TaskJornals { get; set; }

        
        
    }
    [MySqlCharset("utf8")]
    public class TaskJornal
    {


        [Key]
        [Display(Name = "Номер")]
    
        public int Id { get; set; }

        [Required (ErrorMessage = "Заполните поле 'Название'!")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните поле 'Описание проблемы'!")]
        [Display(Name = "Описание проблемы")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Заполните поле 'Кабинет'!")]
        [Display(Name = "Кабинет")]
        public string Cabinet { get; set; }

        [Required(ErrorMessage = "Заполните поле 'ФИО сотрудника'!")]
        [Display(Name = "ФИО сотрудника")]
        public string Fio { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Display(Name = "Дата принятия в работу")]
        public DateTime? WorkDate { get; set; }

        [Display(Name = "Статус")]

       public int StateId { get; set; }
       
        public State States { get; set; }

    }
}
