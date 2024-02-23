using System;
using TodoList.Models;

namespace ToDoList.Services
{
	public interface IDataService
	{
		public List<Tarea> Tasks
		{
			get; set;

		}

		public void AddTask(Tarea tarea);
		public List<Tarea> GetTasks();
	}
}

