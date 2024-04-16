using System;
using ToDoList.Models;


namespace ToDoList.Services
{
	public interface IDataService
	{
		public List<Tarea> Tasks { get; set; }

		public Task AddTask(Tarea tarea);
        public Task<List<Tarea>> GetTasks();
        //Task<bool> DeleteTaskAsync(Tarea tarea);
        Task<bool> EditTaskAsync(Tarea tarea);


    }
}

