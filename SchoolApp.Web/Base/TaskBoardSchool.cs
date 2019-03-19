using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Web.Models;

namespace SchoolApp.Web.Base
{
    public class TaskBoardSchool : ITaskBoardSchool
    {
        private ApplicationDbContext context;

        private StatusTaskBoardSchool status = StatusTaskBoardSchool.Created;

        public StatusTaskBoardSchool Status
        {
            get
            {
                return status;
            }
        }

        public TaskBoardSchool(ApplicationDbContext db)
        {
            context = db;
        }

        public void AddTask(TaskJornal t)
        {
            try
            {
                t.States = context.States.Find((int)status);
                context.TaskJornals.Add(t);
                context.SaveChanges();
            }
            catch (ApplicationException)
            {
                throw new ApplicationException("Ошибка при создании новой задачи!");
            }

        }

        public void DeleteTask(int id)
        {
            try
            {
                var deletedTask = context.TaskJornals.Find(id);
                context.TaskJornals.Remove(deletedTask);
                context.SaveChanges();
                status = StatusTaskBoardSchool.Deleted;
            }
            catch (ApplicationException)
            {
                throw new ApplicationException("Ошибка при удалении задачи!");
            }

        }

        public void InProcess(int id)
        {
            SetStatusTask(id, StatusTaskBoardSchool.InProcess);
        }

        public void Сompleted(int id)
        {
            SetStatusTask(id, StatusTaskBoardSchool.Сompleted);
        }

        private void SetStatusTask(int idTask, StatusTaskBoardSchool status)
        {
            try
            {
                var updateTask = context.TaskJornals.Find(idTask);
                updateTask.StateId = (int)status;
                updateTask.WorkDate = DateTime.Now;
                context.Entry(updateTask).State = EntityState.Modified;
                context.SaveChanges();
                this.status = status;
            }
            catch (ApplicationException)
            {
                throw new ApplicationException($"Ошибка при модификации задачи!");
            }
        }

        public IList<TaskJornal> GetRealTask()
        {
            return context.TaskJornals.Where(x => x.States.Id != 4).Include(c => c.States).ToList<TaskJornal>();
        }

        public IList<TaskJornal> GetAllTask()
        {
            return context.TaskJornals.Include(c => c.States).ToList<TaskJornal>();
        }

        public TaskJornal GetTask(int id)
        {
            return context.TaskJornals.Find(id);
        }
    }
}
