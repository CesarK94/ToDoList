using System;
namespace ToDoList.Services
{
	public class SQLiteDataService : IDataService
	{
        public List<Tarea> Tasks
        {
            get; set;

        }

        public void AddTask(Tarea tarea);
        public List<Tarea> GetTasks();
    }
}

