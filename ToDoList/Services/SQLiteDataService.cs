using SQLite;
using System;
using ToDoList.Models;
using ToDoList.Models.Encuestas;
namespace ToDoList.Services
{
	public class SQLiteDataService : IDataService
	{
        public List<Tarea> Tasks { get; set; }
        public const string DatabaseFilename = "MI_DB_TODO2.db";
        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
            SQLiteConnection dataBase;

        public SQLiteDataService()
        {
            Tasks = new List<Tarea>();
            dataBase = new SQLiteConnection(DatabasePath, Flags);

            dataBase.CreateTable<Pregunta>();
            dataBase.CreateTable<Respuesta>();
            dataBase.CreateTable<Encuesta>();
            dataBase.CreateTable<Tarea>();
        }

        public async Task AddTask(Tarea tarea)
        {
            dataBase.Insert(tarea);
        }
        List<Tarea> IDataService.GetTasks()
        {
            Tasks = dataBase.Table<Tarea>().ToList();
            return Tasks;
        }
    }
}

