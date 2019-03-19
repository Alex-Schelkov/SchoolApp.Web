using SchoolApp.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolApp.Web.Base
{
    interface ITaskBoardSchool
    {
        void AddTask(TaskJornal t);
        void DeleteTask(int id);
        void InProcess(int id);
        void Сompleted(int id);
        StatusTaskBoardSchool Status { get; }
        IList<TaskJornal> GetRealTask();
        IList<TaskJornal> GetAllTask();
        TaskJornal GetTask(int id);

    }

    public enum StatusTaskBoardSchool
    {
        Created = 1,
        InProcess = 2,
        Сompleted = 3,
        Deleted = 4
    }

}
