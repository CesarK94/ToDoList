using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class FakeTaskService
    {
        public List<Tarea> Tasks { get; set; }
        public FakeTaskService()
        {
            Tasks = new();
        }

        public void AddTask(Tarea tarea)
        {
            Tasks.Add(tarea);
        }

        public List<Tarea> GetTasks()
        {
            return Tasks;
        }
    }
}
