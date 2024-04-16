using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using ToDoList.Models;

namespace ToDoList.Services
{
	public class FirebaseDataService : IDataService
	{
        public List<Tarea> Tasks { get; set; } = new();
        FirebaseClient firebaseClient;

        public FirebaseDataService()
        {
            firebaseClient = new FirebaseClient("https://todolist-7e01a-default-rtdb.firebaseio.com/");
            firebaseClient
                .Child("Todo")
                .AsObservable<Tarea>()
                .Subscribe(item => Tasks.Add(item.Object));
        }

        public async Task AddTask(Tarea tarea)
        {
           await firebaseClient.Child("Todo").PostAsync(tarea);
        }
        public async Task<List<Tarea>> GetTasks()
        {
            return (await firebaseClient.Child("Todo").OnceAsync<Tarea>()).Select(item => new Tarea
            {
                Id = item.Key,
                Titulo = item.Object.Titulo,
                Descripcion = item.Object.Descripcion,
                FechaInicial = item.Object.FechaInicial,
                FechaFinal = item.Object.FechaFinal,
                TipoTarea = item.Object.TipoTarea,
                Prioridad = item.Object.Prioridad,
                Estado = item.Object.Estado,
                Encuesta = item.Object.Encuesta,
                URl = item.Object.URl

            }).ToList();
        }

        /*
        public async Task<bool> DeleteTaskAsync(Tarea tarea)
        {
            try
            {
                await firebaseClient.Child("Todo").Child(tarea.Id).DeleteAsync();
                return true; // La eliminación fue exitosa
            }
            catch (Exception)
            {
                return false; // La eliminación falló
            }
        }
        */

        public async Task<bool> EditTaskAsync(Tarea tarea)
        {
            try
            {
                await firebaseClient.Child("Todo").Child(tarea.Id).PutAsync(tarea);
                return true; // La edición fue exitosa
            }
            catch (Exception)
            {
                return false; // La edición falló
            }
        }
        
    }

}


